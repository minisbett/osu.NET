﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using osu_sharp.Authorization;
using osu_sharp.Helpers;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;

namespace osu_sharp;

/// <summary>
/// An API client for the osu! API v2.
/// </summary>
/// <param name="accessTokenProvider">The provider for access tokens on the osu! API v2.</param>
public partial class OsuApiClient(IOsuAccessTokenProvider accessTokenProvider, OsuApiClientOptions options, ILogger<OsuApiClient> logger)
{
  private static readonly OsuSharpJsonSerializer _jsonSerializer = new();

  private readonly HttpClient _http = new()
  {
    BaseAddress = new("https://osu.ppy.sh/api/v2/"),
    DefaultRequestHeaders =
    {
      { "x-api-version", "20220705" },
      { "User-Agent", options.UserAgent }
    },
    Timeout = options.RequestTimeout
  };

  /// <summary>
  /// Ensures the access token is set on the HTTP client.
  /// </summary>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  private async Task EnsureAccessTokenAsync(CancellationToken cancellationToken)
  {
    string token = await accessTokenProvider.GetAccessTokenAsync(cancellationToken);
    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
  }

  /// <summary>
  /// Sends a request to the specified URL, performing logging and exception handling.
  /// </summary>
  /// <param name="url">The request URL.</param>
  /// <param name="parameters">The query parameters of the URL. Parameters with a null value will be ignored.</param>
  /// <param name="method">The HTTP method used for the request.</param>
  /// <param name="cancellationToken">The cancellation token for aborting the request.</param>
  /// <returns>The HTTP response.</returns>
  private async Task<HttpResponseMessage> SendAsync(string url, Dictionary<string, object?> parameters, HttpMethod method,
                                                           CancellationToken cancellationToken)
  {
    Stopwatch watch = Stopwatch.StartNew();
    await EnsureAccessTokenAsync(cancellationToken);

    HttpResponseMessage? response = null;
    try
    {
      response = await _http.SendAsync(new(method, APIUtils.GetRequestUrl(url, parameters)), cancellationToken);
    }
    catch (Exception ex)
    {
      if (options.EnableLogging)
        logger.LogError(ex, "Failed to send the API request.");

      throw new OsuApiException("Failed to send the API request.", ex);
    }
    finally
    {
      watch.Stop();
      if (options.EnableLogging)
        logger.LogInformation(
          """
                 URL: {Url}
            Duration: {Time:N0}ms
              Status: {Status}
          Parameters: {Params}
          """, _http.BaseAddress + url, watch.ElapsedMilliseconds, response is null ? "Error" : $"{(int)response.StatusCode} ({response.StatusCode})",
               parameters.Count == 0 ? "None" : parameters);
    }

    return response;
  }

  /// <summary>
  /// Sends a GET request to the specified URL and parses the JSON in the response into the specified type.<br/>
  /// If the request fails, an <see cref="OsuApiException"/> is thrown.
  /// </summary>
  /// <typeparam name="T">The type to parse the JSON response into.</typeparam>
  /// <param name="url">The request URL.</param>
  /// <param name="cancellationToken">The cancellation token for aborting the request.</param>
  /// <param name="parameters">Optional. The query parameters of the URL. Parameters with a null value will be ignored.</param>
  /// <param name="jsonSelector">Optional. A JSON selector for parsing nested objects instead of the root JSON.</param>
  /// <param name="method">Optional. The HTTP method used for the request. Defaults to GET.</param>
  /// <returns>The parsed API result.</returns>
  private async Task<APIResult<T>> GetAsync<T>(string url, CancellationToken? cancellationToken, Dictionary<string, object?>? parameters = null,
                                               Func<JObject, JToken?>? jsonSelector = null, HttpMethod? method = null) where T : class
  {
    cancellationToken ??= CancellationToken.None;
    parameters ??= [];
    method ??= HttpMethod.Get;

    HttpResponseMessage response = await SendAsync(url, parameters, method, cancellationToken.Value);

    // If the API does not respond with an OK (request successful) or NotFound/UnprocessableEntity (something not found),
    // the request is likely malformed or the osu! API encountered an internal server error. This ensures that any APIResult<T>
    // retrieved by the end user possibly contains an error caused via their own input, and not some API wrapper or osu!-sided issue.
    if (response.StatusCode is not HttpStatusCode.OK or HttpStatusCode.NotFound or HttpStatusCode.UnprocessableEntity)
      throw new OsuApiException($"API responded with an unexpected status code: {response.StatusCode}.");

    try
    {
      string json = await response.Content.ReadAsStringAsync(cancellationToken.Value);

      // If the API responds with an error field, use it to determine which APIError object to return.
      JValue? error = JsonConvert.DeserializeObject<dynamic>(json)?["error"];
      if (error is not null)
        return APIError.FromErrorMessage(error.Value<string>());
      else if (response.StatusCode is not HttpStatusCode.OK) // If the request was not successful but no error message was provided, assume null
        return APIError.FromErrorMessage(null);

      if (typeof(T).IsArray)
        return JArray.Parse(json).ToObject<T?>(_jsonSerializer);

      JObject obj = JObject.Parse(json);
      JToken token = jsonSelector?.Invoke(obj) ?? obj;

      return token.ToObject<T?>(_jsonSerializer);
    }
    catch (Exception ex)
    {
      if (options.EnableLogging)
        logger.LogError(ex, "Failed to parse the API response into a {Type} object.", typeof(T));

      throw new OsuApiException($"Failed to parse the API response into a {typeof(T)} object.", ex);
    }
  }
}
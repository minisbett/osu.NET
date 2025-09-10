using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using osu.NET.Authorization;
using osu.NET.Helpers;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;

namespace osu.NET;

/// <summary>
/// An API client for the osu! API v2.
/// </summary>
/// <param name="accessTokenProvider">The provider for access tokens on the osu! API v2.</param>
/// <param name="logger">The logger for the API client.</param>
public partial class OsuApiClient(IOsuAccessTokenProvider accessTokenProvider, ILogger<OsuApiClient>? logger)
{
  private static readonly JsonSerializer _jsonSerializer = OsuJsonSerializer.Create();

  /// <summary>
  /// The HTTP client used by the API client.
  /// </summary>
  protected HttpClient Http { get; } = new()
  {
    BaseAddress = new("https://osu.ppy.sh/api/v2/"),
    DefaultRequestHeaders =
    {
      { "x-api-version", "20220705" }
    }
  };

  /// <summary>
  /// Ensures the access token is set on the HTTP client.
  /// </summary>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  private async Task EnsureAccessTokenAsync(CancellationToken cancellationToken)
  {
    string token = await accessTokenProvider.GetAccessTokenAsync(cancellationToken);
    Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
  }

  /// <summary>
  /// Sends the specified request and handles any exceptions that may occur.
  /// </summary>
  /// <param name="request">The HTTP request.</param>
  /// <param name="cancellationToken">The cancellation token for aborting the request.</param>
  /// <returns>The HTTP response.</returns>
  protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
  {
    await EnsureAccessTokenAsync(cancellationToken);

    Stopwatch watch = Stopwatch.StartNew();
    HttpResponseMessage? response = null;
    try
    {
      response = await Http.SendAsync(request, cancellationToken);
    }
    catch (Exception ex)
    {
      logger?.LogError(ex, "Failed to send the API request.");
      throw new OsuApiException("Failed to send the API request.", ex);
    }
    finally
    {
      string status = response is null ? "Error" : $"{(int)response.StatusCode} ({response.StatusCode})";
      logger?.LogInformation("URL: {Url}\r\nDuration: {Time:N0}ms\r\nStatus: {Status}", request.RequestUri, watch.ElapsedMilliseconds, status);
    }

    // If the API does not respond with OK (request successful), NotFound/UnprocessableEntity (something not found) or Forbidden (missing permissions),
    // the request is likely malformed or the osu! API encountered an internal server error. This ensures that any APIResult<T>
    // retrieved by the end user possibly contains an error caused via their own input, and not some API wrapper or osu!-sided issue.
    if (response.StatusCode is not (HttpStatusCode.OK or HttpStatusCode.NotFound or HttpStatusCode.UnprocessableEntity or HttpStatusCode.Forbidden))
      throw new OsuApiException($"API responded with an unexpected status code: {response.StatusCode}.");

    return response;
  }

  /// <summary>
  /// Parses the JSON response of the specified HTTP response into the specified type.
  /// </summary>
  /// <typeparam name="T">The type to parse the JSON response into.</typeparam>
  /// <param name="response">The HTTP response.</param>
  /// <param name="jsonSelector">A JSON selector for parsing nested objects instead of the root JSON.</param>
  /// <param name="cancellationToken">The cancellation token for aborting the request.</param>
  /// <returns>The parsed API result.</returns>
  protected async Task<ApiResult<T>> ParseAsync<T>(HttpResponseMessage response, Func<JObject, JToken?>? jsonSelector,
    CancellationToken cancellationToken) where T : class
  {
    try
    {
      string json = await response.Content.ReadAsStringAsync(cancellationToken);
      JToken token = JToken.Parse(json);
      JObject? obj = token as JObject;

      // If the status code is not OK, check for an error in the JSON.
      if (!response.IsSuccessStatusCode)
      {
        string? error = obj?["error"]?.Value<string>();
        return ApiError.FromMessage(error);
      }

      if (obj is not null && jsonSelector is not null)
        token = jsonSelector.Invoke(obj) ?? token;

      return token.ToObject<T?>(_jsonSerializer);
    }
    catch (Exception ex)
    {
      logger?.LogError(ex, "Failed to parse the API response into a {Type} object.", typeof(T));
      throw new OsuApiException($"Failed to parse the API response into a {typeof(T)} object.", ex);
    }
  }

  /// <summary>
  /// Sends a GET request to the specified URL and parses the JSON in the response into the specified type.
  /// </summary>
  /// <typeparam name="T">The type to parse the JSON response into.</typeparam>
  /// <param name="url">The request URL.</param>
  /// <param name="cancellationToken">The cancellation token for aborting the request.</param>
  /// <param name="parameters">Optional. The query parameters of the URL. Parameters with a null value will be ignored.</param>
  /// <param name="jsonSelector">Optional. A JSON selector for parsing nested objects instead of the root JSON.</param>
  /// <returns>The parsed API result.</returns>
  protected async Task<ApiResult<T>> GetAsync<T>(string url, CancellationToken? cancellationToken, (string, object?)[]? parameters = null,
    Func<JObject, JToken?>? jsonSelector = null) where T : class
  {
    url = BuildRequestUrl(url, parameters ?? []);
    cancellationToken ??= CancellationToken.None;

    HttpResponseMessage response = await SendAsync(new(HttpMethod.Get, url), cancellationToken.Value);
    return await ParseAsync<T>(response, jsonSelector, cancellationToken.Value);
  }

  /// <summary>
  /// Sends a POST request to the specified URL and parses the JSON in the response into the specified type.
  /// </summary>
  /// <typeparam name="T">The type to parse the JSON response into.</typeparam>
  /// <param name="url">The request URL.</param>
  /// <param name="cancellationToken">The cancellation token for aborting the request.</param>
  /// <param name="parameters">Optional. The query parameters of the URL. Parameters with a null value will be ignored.</param>
  /// <param name="jsonSelector">Optional. A JSON selector for parsing nested objects instead of the root JSON.</param>
  /// <param name="httpContent">The body content used for the request.</param>
  /// <returns>The parsed API result.</returns>
  protected async Task<ApiResult<T>> PostAsync<T>(string url, CancellationToken? cancellationToken, (string, object?)[]? parameters = null,
    Func<JObject, JToken?>? jsonSelector = null, HttpContent? httpContent = null) where T : class
  {
    url = BuildRequestUrl(url, parameters ?? []);
    cancellationToken ??= CancellationToken.None;

    HttpResponseMessage response = await SendAsync(new(HttpMethod.Post, url) { Content = httpContent }, cancellationToken.Value);
    return await ParseAsync<T>(response, jsonSelector, cancellationToken.Value);
  }

  /// <summary>
  /// Returns the request URL based on the specified base URL and query parameters, excluding those parameters with a null value.
  /// </summary>
  /// <param name="url">The base request URL.</param>
  /// <param name="queryParameters">The query parameters.</param>
  /// <returns>The request URL.</returns>
  protected static string BuildRequestUrl(string url, (string Key, object? Value)[] queryParameters)
  {
    url = $"{url.TrimEnd('/')}?";

    foreach ((string key, object? value) in queryParameters.Where(x => x.Value is not null))
    {
      string valueStr = value switch
      {
        Enum e => e.GetQueryName(),       // Enum     -> APIQueryName attribute
        DateTime dt => dt.ToString("o"),  // DateTime -> ISO 8601
        bool b => b.ToString().ToLower(), // bool     -> lower-case
        _ => value!.ToString()!
      };

      url += $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(valueStr)}&";
    }

    return url.TrimEnd('?').TrimEnd('&');
  }
}

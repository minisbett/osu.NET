using Newtonsoft.Json;
using osu.NET.Models.Responses;

namespace osu.NET.Authorization;


/// <summary>
/// A client for managing OAuth code flow.
/// </summary>
/// <param name="clientId">The client ID.</param>
/// <param name="clientSecret">The client secret.</param>
/// <param name="redirectUrl">The redirect/callback URL.</param>
public class OsuOAuthClient(string clientId, string clientSecret, string redirectUrl)
{
  private readonly HttpClient _http = new()
  {
    BaseAddress = new("https://osu.ppy.sh/api/v2/")
  };

  /// <summary>
  /// Builds an OAuth redirect URL for the specified scopes with the specified state.
  /// </summary>
  /// <param name="state">The state (eg. for XSRF-tokens).</param>
  /// <param name="scopes">The requested scopes.</param>
  /// <returns>THe OAuth redirect URL.</returns>
  public string BuildRedirectUrl(string state, params string[] scopes)
  {
    Dictionary<string, string> queryParameters = new()
    {
      ["client_id"] = clientId,
      ["redirect_uri"] = redirectUrl,
      ["scope"] = string.Join(' ', scopes),
      ["response_type"] = "code",
      ["state"] = state
    };

    return $"https://osu.ppy.sh/oauth/authorize?{string.Join('&', queryParameters.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"))}";
  }

  /// <summary>
  /// Exchanges the specified authorization code for an access token.
  /// </summary>
  /// <param name="code">The authorization code.</param>
  /// <param name="cancellationToken">The cancellation token for aborting the request.</param>
  /// <returns>The code exchange response.</returns>
  public async Task<OsuCodeExchangeResponse> ExchangeCodeAsync(string code, CancellationToken cancellationToken)
  {
    HttpResponseMessage response;
    try
    {
      response = await _http.PostAsync("https://osu.ppy.sh/oauth/token", new FormUrlEncodedContent(new Dictionary<string, string>
      {
        ["client_id"] = clientId,
        ["client_secret"] = clientSecret,
        ["redirect_uri"] = redirectUrl,
        ["grant_type"] = "authorization_code",
        ["code"] = code
      }), cancellationToken);
    }
    catch (Exception ex)
    {
      throw new AccessTokenRetrievalException("Failed to send the token exchange request.", ex);
    }

    string json = await response.Content.ReadAsStringAsync(cancellationToken);

    OsuCodeExchangeResponse accessToken;
    try
    {
      accessToken = JsonConvert.DeserializeObject<OsuCodeExchangeResponse>(json) ?? throw new("The response is null.");
    }
    catch (Exception ex)
    {
      throw new AccessTokenRetrievalException("Failed to parse the code exchange response.", ex);
    }

    // If the response is not successful, there should be an error description indicating what went wrong.
    // Also handle the case where the access token or expiration date is null but the response was successful, which should not happen.
    if (!response.IsSuccessStatusCode)
      throw new AccessTokenRetrievalException($"{response.StatusCode}: {accessToken.ErrorDescription}");
    else if (accessToken.AccessToken is null || accessToken.RefreshToken is null || accessToken.ExpiresIn is null)
      throw new AccessTokenRetrievalException("The access token or expiration date is null, but no error was reported.");

    return accessToken;
  }
}

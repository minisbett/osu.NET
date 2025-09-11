using Newtonsoft.Json;

namespace osu.NET.Models.Responses;

/// <summary>
/// Represents the response from a code exchange request via an <see cref="Authorization.OsuOAuthClient"/>.
/// </summary>
public class OsuCodeExchangeResponse
{
  /// <summary>
  /// The access token. If null, an error likely occured.
  /// </summary>
  [JsonProperty("access_token")]
  public string AccessToken { get; private set; } = null!;

  /// <summary>
  /// The refresh token. If null, an error likely occured.
  /// </summary>
  [JsonProperty("refresh_token")]
  public string RefreshToken { get; private set; } = null!;

  /// <summary>
  /// The amount of seconds in which the access token will expire. If null, an error likely occured.
  /// </summary>
  [JsonProperty("expires_in")]
  public int? ExpiresIn { get; private set; }

  /// <summary>
  /// The description of the authorization error. If null, no error occurred.
  /// </summary>
  [JsonProperty("error_description")]
  public string? ErrorDescription { get; private set; }
}
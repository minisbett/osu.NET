namespace osu.NET;

/// <summary>
/// Represents options for an <see cref="OsuApiClient"/>.
/// </summary>
public class OsuApiClientOptions
{
  /// <summary>
  /// The timeout for API requests. Defaults to the default of <see cref="HttpClient.Timeout"/>, which is 100 seconds.
  /// </summary>
  public TimeSpan RequestTimeout { get; set; } = TimeSpan.FromSeconds(100);
}

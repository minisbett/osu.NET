using Newtonsoft.Json;
using osu.NET.Models.Users;

namespace osu.NET.Models.Other;

/// <summary>
/// Represents a seasonal background with its' asset URL and user who created it.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/SeasonalBackgroundsController.php"/>
/// </summary>
public class SeasonalBackground
{
  /// <summary>
  /// The URL to the asset of this seasonal background.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; set; } = default!;

  /// <summary>
  /// The creator of this seasonal background.
  /// </summary>
  [JsonProperty("user")]
  public User User { get; set; } = default!;
}

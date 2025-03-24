using Newtonsoft.Json;

namespace osu.NET.Models.Other;

/// <summary>
/// Represents the current seasonal backgrounds in osu! and when their season ends.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/SeasonalBackgroundsController.php"/>
/// </summary>
public class SeasonalBackgroundsBundle
{
  /// <summary>
  /// The datetime at which the season with the current background ends.
  /// </summary>
  [JsonProperty("ends_at")]
  public DateTimeOffset EndsAt { get; private set; } = default!;

  /// <summary>
  /// The seasonal backgrounds.
  /// </summary>
  [JsonProperty("backgrounds")]
  public SeasonalBackground[] Backgrounds { get; private set; } = default!;
}

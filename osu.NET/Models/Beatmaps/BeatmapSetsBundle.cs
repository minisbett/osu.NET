using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents a bundle containing beatmapsets and the cursor string for pagination.
/// <br/><br/>
/// API docs: Undocumented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/BeatmapsetsController.php"/>
/// </summary>
public class BeatmapSetsBundle
{
  /// <summary>
  /// The beatmapsets.
  /// </summary>
  [JsonProperty("beatmapsets")]
  public BeatmapSetExtended[] Sets { get; init; } = default!;

  /// <summary>
  /// The cursor string for fetching further beatmapsets.
  /// </summary>
  [JsonProperty("cursor_string")]
  public string Cursor { get; init; } = default!;
}
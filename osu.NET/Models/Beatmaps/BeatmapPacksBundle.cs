using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents a bundle containing beatmap packs and the cursor string for pagination.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-packs"/> (response)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/BeatmapPacksController.php"/>
/// </summary>
public class BeatmapPacksBundle
{
  /// <summary>
  /// The beatmap packs.
  /// </summary>
  [JsonProperty("beatmap_packs")]
  public BeatmapPack[] Packs { get; init; } = default!;

  /// <summary>
  /// The cursor string for fetching further beatmap packs.
  /// </summary>
  [JsonProperty("cursor_string")]
  public string Cursor { get; init; } = default!;
}
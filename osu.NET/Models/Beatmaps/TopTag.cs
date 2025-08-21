using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents one of the top-voted tags on a beatmap.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmap-json.ts"/>
/// </summary>
public class TopTag
{
  /// <summary>
  /// The ID of the tag.
  /// </summary>
  [JsonProperty("tag_id")]
  public int TagId { get; private set; }

  /// <summary>
  /// The amount of times the tag was voted.
  /// </summary>
  [JsonProperty("count")]
  public int Count { get; private set; }
}

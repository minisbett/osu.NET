using Newtonsoft.Json;

namespace osu.NET.Models.Events;

/// <summary>
/// Represents the beatmapset associated with a <see cref="Event"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-beatmapset"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class EventBeatmapset
{
  /// <summary>
  /// The title of the beatmapset.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; init; } = default!;

  /// <summary>
  /// The URL of the beatmapset.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; init; } = default!;
}

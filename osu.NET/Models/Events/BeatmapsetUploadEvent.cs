using Newtonsoft.Json;

namespace osu.NET.Models.Events;

/// <summary>
/// Represents the event when a user uploads a new beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapsetUploadEvent : Event
{
  /// <summary>
  /// The beatmapset that was uploaded.
  /// </summary>
  [JsonProperty("beatmapset")]
  public EventBeatmapset Beatmapset { get; init; } = default!;

  /// <summary>
  /// The user who uploaded the beatmapset.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; init; } = default!;
}

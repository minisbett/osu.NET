using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Events;

/// <summary>
/// Represents the event when a beatmap of a user changes the state to ranked, approved, qualified or loved.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapsetApproveEvent : Event
{
  /// <summary>
  /// The approval state of the beatmapset.
  /// </summary>
  [JsonProperty("approval")]
  public BeatmapsetEventApproval Approval { get; init; } = default!;

  /// <summary>
  /// The beatmapset associated with this event.
  /// </summary>
  [JsonProperty("beatmapset")]
  public EventBeatmapset Beatmapset { get; init; } = default!;

  /// <summary>
  /// The user who is the owner of this beatmapset.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; init; } = default!;
}

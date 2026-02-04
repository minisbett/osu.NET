using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Events;

/// <summary>
/// Represents the event when a user achieves a certain rank on a beatmap.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class RankEvent : Event
{
  /// <summary>
  /// The rank achieved by the user.
  /// </summary>
  [JsonProperty("rank")]
  public int Rank { get; init; }

  /// <summary>
  /// The grade achieved by the user.
  /// </summary>
  [JsonProperty("scoreRank")]
  public Grade ScoreRank { get; init; } = default!;

  /// <summary>
  /// The ruleset this event takes place in.
  /// </summary>
  [JsonProperty("mode")]
  public Ruleset Ruleset { get; init; } = default!;

  /// <summary>
  /// The beatmap associated with this event.
  /// </summary>
  [JsonProperty("beatmap")]
  public EventBeatmap Beatmap { get; init; } = default!;

  /// <summary>
  /// The user associated with this event.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; init; } = default!;
}

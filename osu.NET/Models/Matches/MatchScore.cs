using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Matches;

/// <summary>
/// Represents a score in a match.s.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#score"/> (uses the old score model)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/score-json.ts"/>
/// </summary>
public class MatchScore
{
  /// <summary>
  /// The accuracy of this score.
  /// </summary>
  [JsonProperty("accuracy")]
  public float Accuracy { get; init; }

  /// <summary>
  /// The datetime at which this score was submitted to the osu! servers.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; init; }

  /// <summary>
  /// The maximum combo achieved in this score.
  /// </summary>
  [JsonProperty("max_combo")]
  public int MaxCombo { get; init; }

  /// <summary>
  /// The ruleset this score was set in.
  /// </summary>
  [JsonProperty("mode")]
  public Ruleset Ruleset { get; init; }

  /// <summary>
  /// the mods used in this score.
  /// </summary>
  [JsonProperty("mods")]
  public string[] Mods { get; init; } = default!;

  /// <summary>
  /// Bool whether the user passed the beatmap of this score.
  /// </summary>
  [JsonProperty("passed")]
  public bool IsPassed { get; init; }

  /// <summary>
  /// Bool whether this score has the maximum combo possible.
  /// </summary>
  [JsonProperty("perfect")]
  public bool IsPerfect { get; init; }

  /// <summary>
  /// The grade of this score.
  /// </summary>
  [JsonProperty("rank")]
  public Grade Grade { get; init; }

  /// <summary>
  /// The total score of this score.
  /// </summary>
  [JsonProperty("score")]
  public int TotalScore { get; init; }

  /// <summary>
  /// The hit statistics of this score.
  /// </summary>
  [JsonProperty("statistics")]
  public MatchScoreStatistics Statistics { get; init; } = default!;

  /// <summary>
  /// The ID of the user that submitted this score.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; init; }

  /// <summary>
  /// The team and slot of the user that submitted this score in the match.
  /// </summary>
  [JsonProperty("slot")]
  public ScoreMatchSlot Slot { get; init; } = default!;
}

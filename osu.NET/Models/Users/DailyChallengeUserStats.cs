using Newtonsoft.Json;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents the daily challenge statistics of a user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/daily-challenge-user-stats-json.ts"/>
/// </summary>
public class DailyChallengeUserStats
{
  /// <summary>
  /// The highest daily streak of the user.
  /// </summary>
  [JsonProperty("daily_streak_best")]
  public int BestDailyStreak { get; init; }

  /// <summary>
  /// The current daily streak of the user.
  /// </summary>
  [JsonProperty("daily_streak_current")]
  public int CurrentDailyStreak { get; init; }

  /// <summary>
  /// The datetime at which these statistics were last updated. This may be null.
  /// </summary>
  [JsonProperty("last_update")]
  public DateTimeOffset? LastUpdate { get; init; }

  /// <summary>
  /// DOCS: what is this?
  /// </summary>
  [JsonProperty("last_weekly_streak")]
  public DateTimeOffset? LastWeeklyStreak { get; init; }

  /// <summary>
  /// The amount of daily challenges the user has played.
  /// </summary>
  [JsonProperty("playcount")]
  public int Playcount { get; init; }

  /// <summary>
  /// The amount of times the user has placed in the top 10% of a daily challenge.
  /// </summary>
  [JsonProperty("top_10p_placements")]
  public int Top10PercentPlacement { get; init; }

  /// <summary>
  /// The amount of times the user has placed in the top 50% of a daily challenge.
  /// </summary>
  [JsonProperty("top_50p_placements")]
  public int Top50PercentPlacement { get; init; }

  /// <summary>
  /// The ID of the user these statistics belong to.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; init; }

  /// <summary>
  /// The highest weekly streak of the user.
  /// </summary>
  [JsonProperty("weekly_streak_best")]
  public int BestWeeklyStreak { get; init; }

  /// <summary>
  /// The current weekly streak of the user.
  /// </summary>
  [JsonProperty("weekly_streak_current")]
  public int CurrentWeeklyStreak { get; init; }
}

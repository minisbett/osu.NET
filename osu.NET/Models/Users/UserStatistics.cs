using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents the statistics of a user.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#userstatistics"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-statistics-json.ts"/>
/// </summary>
public class UserStatistics
{
  /// <summary>
  /// The amount of total 300 hit judgements the user has.
  /// </summary>
  [JsonProperty("count_300")]
  public int Count300 { get; init; }

  /// <summary>
  /// The amount of total 100 hit judgements the user has.
  /// </summary>
  [JsonProperty("count_100")]
  public int Count100 { get; init; }

  /// <summary>
  /// The amount of total 50 hit judgements the user has.
  /// </summary>
  [JsonProperty("count_50")]
  public int Count50 { get; init; }

  /// <summary>
  /// The amount of total misses the user has.
  /// </summary>
  [JsonProperty("count_miss")]
  public int Misses { get; init; }

  /// <summary>
  /// The country rank of the user. This may be null.
  /// </summary>
  [JsonProperty("country_rank")]
  public int? CountryRank { get; init; }

  /// <summary>
  /// The global rank of the user. This may be null.
  /// </summary>
  [JsonProperty("global_rank")]
  public int? GlobalRank { get; init; }

  /// <summary>
  /// The amount of times the user achieved the XH, X, SH, S and A grades.
  /// </summary>
  [JsonProperty("grade_counts")]
  public Dictionary<Grade, int> Grades { get; init; } = default!;

  /// <summary>
  /// The overall accuracy of the user.
  /// </summary>
  [JsonProperty("hit_accuracy")]
  public float Accuracy { get; init; }

  /// <summary>
  /// DOCS: what is this? can user statistics be ranked and unranked?
  /// </summary>
  [JsonProperty("is_ranked")]
  public bool IsRanked { get; init; }

  /// <summary>
  /// The level of the user.
  /// </summary>
  [JsonProperty("level")]
  public Level Level { get; init; } = default!;

  /// <summary>
  /// The highest combo the user has ever achieved.
  /// </summary>
  [JsonProperty("maximum_combo")]
  public int MaxCombo { get; init; }

  /// <summary>
  /// The total playcount of the user.
  /// </summary>
  [JsonProperty("play_count")]
  public int PlayCount { get; init; }

  /// <summary>
  /// The total playtime of the user, in seconds. This will be null in a context where this statistic is not used (eg. spotlight rankings).
  /// </summary>
  [JsonProperty("play_time")]
  public int? PlayTime { get; init; }

  /// <summary>
  /// The total performance points the user has. This will be null in a context where this statistic is not used (eg. spotlight rankings).
  /// </summary>
  [JsonProperty("pp")]
  public float? PP { get; init; }

  /// <summary>
  /// The total ranked score the user has.
  /// </summary>
  [JsonProperty("ranked_score")]
  public long RankedScore { get; init; }

  /// <summary>
  /// The total score the user has.
  /// </summary>
  [JsonProperty("total_score")]
  public long TotalScore { get; init; }

  /// <summary>
  /// the total hits the user has.
  /// </summary>
  [JsonProperty("total_hits")]
  public int TotalHits { get; init; }

  /// <summary>
  /// The variants of these statistics.
  /// </summary>
  [JsonProperty("variants")]
  public StatisticsVariant[]? Variants { get; init; }

  /// <summary>
  /// The rank change of the user in the past 30 days. This is an optional property and may be null.
  /// </summary>
  public int? RankChangeSince30Days { get; init; }

  /// <summary>
  /// The user these statistics belong to. This will be null if the statistics are accessed through a user object.
  /// </summary>
  [JsonProperty("user")]
  public User? User { get; init; } = default!;
}
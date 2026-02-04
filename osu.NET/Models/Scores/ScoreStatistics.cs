using Newtonsoft.Json;

namespace osu.NET.Models.Scores;

/// <summary>
/// Represents the score statistics (hit judgements) of a score. If a score does not contain a certain judgement type, it will be null.
/// </summary>
public class ScoreStatistics
{
  /// <summary>
  /// The Perfect judgements of the score. This will be null if the score does not have any Perfect judgements.
  /// </summary>
  [JsonProperty("perfect")]
  public int? Perfect { get; init; }

  /// <summary>
  /// The Great judgements of the score. This will be null if the score does not have any Great judgements.
  /// </summary>
  [JsonProperty("great")]
  public int? Great { get; init; }

  /// <summary>
  /// The Good judgements of the score. This will be 0 if the score does not have any Good judgements.
  /// </summary>
  [JsonProperty("good")]
  public int? Good { get; init; }

  /// <summary>
  /// The Ok judgements of the score. This will be null if the score does not have any Ok judgements.
  /// </summary>
  [JsonProperty("ok")]
  public int? Ok { get; init; }

  /// <summary>
  /// The Meh judgements of the score. This will be null if the score does not have any Meh judgements.
  /// </summary>
  [JsonProperty("meh")]
  public int? Meh { get; init; }

  /// <summary>
  /// The Miss judgements of the score. This will be null if the score does not have any Miss judgements.
  /// </summary>
  [JsonProperty("miss")]
  public int? Miss { get; init; }

  /// <summary>
  /// The Large Tick Hit judgements of the score. This will be null if the score does not have any Large Tick Hit judgements.
  /// </summary>
  [JsonProperty("large_tick_hit")]
  public int? LargeTickHit { get; init; }

  /// <summary>
  /// The Large Tick Miss judgements of the score. This will be null if the score does not have any Large Tick Miss judgements.
  /// </summary>
  [JsonProperty("large_tick_miss")]
  public int? LargeTickMiss { get; init; }

  /// <summary>
  /// The Large Bonus judgements of the score. This will be null if the score does not have any Large Bonus judgements.
  /// </summary>
  [JsonProperty("large_bonus")]
  public int? LargeBonus { get; init; }

  /// <summary>
  /// The Small Tick Hit judgements of the score. This will be null if the score does not have any Small Tick Hit judgements.
  /// </summary>
  [JsonProperty("small_tick_hit")]
  public int? SmallTickHit { get; init; }

  /// <summary>
  /// The Small Tick Miss judgements of the score. This will be null if the score does not have any Small Tick Miss judgements.
  /// </summary>
  [JsonProperty("small_tick_miss")]
  public int? SmallTickMiss { get; init; }

  /// <summary>
  /// The Small Bonus judgements of the score. This will be null if the score does not have any Small Bonus judgements.
  /// </summary>
  [JsonProperty("small_bonus")]
  public int? SmallBonus { get; init; }

  /// <summary>
  /// The Ignore Hit judgements of the score. This will be null if the score does not have any Ignore Hit judgements.
  /// </summary>
  [JsonProperty("ignore_hit")]
  public int? IgnoreHit { get; init; }

  /// <summary>
  /// The Ignore Miss judgements of the score. This will be null if the score does not have any Ignore Miss judgements.
  /// </summary>
  [JsonProperty("ignore_miss")]
  public int? IgnoreMiss { get; init; }

  /// <summary>
  /// The Legacy Combo Increase judgements of the score. This will be null if the score does not have any Legacy Combo Increase judgements.
  /// </summary>
  [JsonProperty("legacy_combo_increase")]
  public int? LegacyComboIncrease { get; init; }
}

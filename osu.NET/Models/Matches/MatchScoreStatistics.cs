using Newtonsoft.Json;

namespace osu.NET.Models.Matches;

/// <summary>
/// Represents the hit statistics of a <see cref="MatchScore"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#score"/> (uses the old score model)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/score-json.ts"/>
/// </summary>
public class MatchScoreStatistics
{
  /// <summary>
  /// The amount of 300s hit in the score.
  /// </summary>
  [JsonProperty("count_300")]
  public int Count300 { get; init; }

  /// <summary>
  /// The amount of 100s hit in the score.
  /// </summary>
  [JsonProperty("count_100")]
  public int Count100 { get; init; }

  /// <summary>
  /// The amount of 50s hit in the score.
  /// </summary>
  [JsonProperty("count_50")]
  public int Count50 { get; init; }

  /// <summary>
  /// The amount of gekis hit in the score.
  /// </summary>
  [JsonProperty("count_geki")]
  public int CountGeki { get; init; }

  /// <summary>
  /// The amount of katus hit in the score.
  /// </summary>
  [JsonProperty("count_katu")]
  public int CountKatu { get; init; }

  /// <summary>
  /// The amount of misses hit in the score.
  /// </summary>
  [JsonProperty("count_miss")]
  public int CountMiss { get; init; }
}

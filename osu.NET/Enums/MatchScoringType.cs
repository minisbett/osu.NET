using osu.NET.Helpers;
using osu.NET.Models.Matches;

namespace osu.NET.Enums;

/// <summary>
/// Represents the scoring type of a <see cref="MatchGame"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#matchgame"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/LegacyMatch/Game.php"/>
/// </summary>
public enum MatchScoringType
{
  /// <summary>
  /// The accuray is used to determine the value of a score.
  /// </summary>
  [JsonAPIName("accuracy")]
  Accuracy,

  /// <summary>
  /// The combo is used to determine the value of a score.
  /// </summary>
  [JsonAPIName("combo")]
  Combo,

  /// <summary>
  /// The total score is used to determine the value of a score.
  /// </summary>
  [JsonAPIName("score")]
  Score,

  /// <summary>
  /// The total score V2 is used to determine the value of a score.
  /// </summary>
  [JsonAPIName("scorev2")]
  ScoreV2
}

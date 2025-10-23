using Newtonsoft.Json;

namespace osu.NET.Models.Matches;

/// <summary>
/// Represents the team and slot of the user that set a <see cref="MatchScore"/> in a match.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#score"/> (uses the old score model)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/score-json.ts"/>
/// </summary>
public class ScoreMatchSlot
{
  /// <summary>
  /// Bool whether the user passed the beatmap.
  /// </summary>
  [JsonProperty("pass")]
  public bool IsPassed { get; private set; }

  /// <summary>
  /// The slot of the user that set the score in the match.
  /// </summary>
  [JsonProperty("slot")]
  public int Slot { get; private set; }

  /// <summary>
  /// the index of the match team the user that set the score is in.
  /// </summary>
  [JsonProperty("team")]
  public int Team { get; private set; }
}

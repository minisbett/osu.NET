using Newtonsoft.Json;

namespace osu.NET.Models.Scores;

/// <summary>
/// Represents the weighting of a score in a users' overall performance.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#score"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/score-json.ts"/>
/// </summary>
public class PPWeight
{
  /// <summary>
  /// The amount of weighted PP the score contributes.
  /// </summary>
  [JsonProperty("pp")]
  public float PP { get; init; }

  /// <summary>
  /// The weight percentage.
  /// </summary>
  [JsonProperty("percentage")]
  public float Percentage { get; init; }
}

using Newtonsoft.Json;

namespace osu.NET.Models.Scores;

/// <summary>
/// Represents a bundle containing scores and the cursor string for pagination.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-scores97"/> (response)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/ScoresController.php"/>
/// </summary>
public class ScoresBundle
{
  /// <summary>
  /// The cursor string for fetching further scores.
  /// </summary>
  [JsonProperty("cursor_string")]
  public string Cursor { get; private set; } = default!;

  /// <summary>
  /// The scores.
  /// </summary>
  [JsonProperty("scores")]
  public Score[] Scores { get; private set; } = default!;
}

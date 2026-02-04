using Newtonsoft.Json;

namespace osu.NET.Models.Matches;

/// <summary>
/// Represents a bundle containing legacy multiplayer matches, related data and the cursor string for pagination.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-matches-listing"/> (response)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/MatchesController.php"/>
/// </summary>
public class MatchesBundle
{
  // params.limit and params.sort (both mirroring the specified query parameters) have been omitted here as they are useless information.

  /// <summary>
  /// The cursor string for fetching further matches.
  /// </summary>
  [JsonProperty("cursor_string")]
  public string Cursor { get; init; } = default!;

  /// <summary>
  /// The matches.
  /// </summary>
  [JsonProperty("matches")]
  public Match[] Matches { get; init; } = default!;
}

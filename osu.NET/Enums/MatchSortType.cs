using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// Represents the sort types for legacy multiplayer matches.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-matches-listing"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/MatchesController.php"/>
/// </summary>
public enum MatchSortType
{
  /// <summary>
  /// Sorts the matches by ID in ascending order.
  /// </summary>
  [QueryApiName("id_asc")]
  IdAscending,

  /// <summary>
  /// Sorts the matches by ID in descending order.
  /// </summary>
  [QueryApiName("id_desc")]
  IdDescending,
}

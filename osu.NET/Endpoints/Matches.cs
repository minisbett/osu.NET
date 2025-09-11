using osu.NET.Enums;
using osu.NET.Internal;
using osu.NET.Models.Matches;
using osu.NET.Models.Users;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#matches

  /// <summary>
  /// Returns a bundle of legacy multiplayer matches and the cursor string for fetching further matches.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-matches-listing"/>
  /// </summary>
  /// <param name="limit">Optional. The amount of matches to return. Ignored if <paramref name="cursor"/> is specified.</param>
  /// <param name="sort">Optional. The sort for the matches. Ignored if <paramref name="cursor"/> is specified.</param>
  /// <param name="cursor">Optional. The cursor string for fetching further matches.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The bundle with matches.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<MatchesBundle>> GetMatchesAsync(int? limit = null, MatchSortType? sort = null, string? cursor = null,
    CancellationToken? cancellationToken = null)
    => await GetAsync<MatchesBundle>("matches", cancellationToken,
    [
      ("limit", limit),
      ("sort", sort),
      ("cursor_string", cursor)
    ]);

  /// <summary>
  /// Returns the legacy multiplayer match with the specified ID, including events in that match and related userse.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.MatchNotFound"/></term>
  ///   <description>The match could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item><see cref="MatchBundle.Users"/> includes <see cref="User.Country"/></item>
  /// </list>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-match"/>
  /// </summary>
  /// <param name="id">The ID of the match.</param>
  /// <param name="beforeId">Optional. Filters the match events for those before this ID.</param>
  /// <param name="afterId">Optional. Filters the match events for those after this ID.</param>
  /// <param name="limit">Optional. The maximum amount of events to return.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The match with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.MatchNotFound)]
  public async Task<ApiResult<MatchBundle>> GetMatchAsync(int id, int? beforeId = null, int? afterId = null, int? limit = null,
    CancellationToken? cancellationToken = null)
    => await GetAsync<MatchBundle>($"matches/{id}", cancellationToken,
    [
      ("before", beforeId),
      ("after", afterId),
      ("limit", limit)
    ]);
}
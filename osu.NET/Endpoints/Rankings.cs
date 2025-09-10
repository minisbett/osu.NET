using osu.NET.Enums;
using osu.NET.Helpers;
using osu.NET.Models.Rankings;
using osu.NET.Models.Users;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#ranking

  // TODOENDPOINT: https://osu.ppy.sh/docs/index.html#get-ranking (pagination)

  /// <summary>
  /// Returns the users on the specified page of the kudosu ranking, sorted by kudosu. One page contains 50 users.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="User.Kudosu"/></item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-kudosu-ranking"/>
  /// </summary>
  /// <param name="page">Optional. The page to return.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The users on the specified page of the kudosu ranking.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<User[]>> GetKudosuRankingAsync(int? page = null, CancellationToken? cancellationToken = null)
    => await GetAsync<User[]>("rankings/kudosu", cancellationToken, [("page", page)], json => json["ranking"]);

  /// <summary>
  /// Returns a list of all beatmap spotlights.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-spotlights"/>
  /// </summary>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The list of beatmap spotlights.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<Spotlight[]>> GetSpotlightsAsync(CancellationToken? cancellationToken = null)
    => await GetAsync<Spotlight[]>("spotlights", cancellationToken, jsonSelector: json => json["spotlights"]);

  /// <summary>
  /// Returns the top 40 ranking of a beatmap spotlight.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-ranking"/>
  /// </summary>
  /// <param name="ruleset">The ruleset in which the rankings are returned.</param>
  /// <param name="spotlightId">Optional. The ID of the spotlight. Defaults to the latest spotlight.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The spotlight ranking.</returns>
  [CanReturnApiError(ApiErrorType.SpotlightNotFound, ApiErrorType.InvalidRulesetForSpotlight)]
  public async Task<ApiResult<SpotlightRanking>> GetSpotlightRankingsAsync(Ruleset ruleset, int? spotlightId = null,
    CancellationToken? cancellationToken = null)
    => await GetAsync<SpotlightRanking>($"rankings/{ruleset.GetQueryName()}/charts?spotlight={spotlightId}", cancellationToken);
}

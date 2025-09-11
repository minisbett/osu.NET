using osu.NET.Enums;
using osu.NET.Internal;
using osu.NET.Models.Rankings;
using osu.NET.Models.Users;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#ranking

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
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.SpotlightNotFound"/></term>
  ///   <description>The spotlight could not be found</description>
  /// </item><br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.InvalidRulesetForSpotlight"/></term>
  ///   <description>The spotlight does not support the specified ruleset</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-ranking"/>
  /// </summary>
  /// <param name="ruleset">The ruleset in which the rankings are returned.</param>
  /// <param name="spotlightId">Optional. The ID of the spotlight. Defaults to the latest spotlight.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The spotlight ranking.</returns>
  [CanReturnApiError(ApiErrorType.SpotlightNotFound, ApiErrorType.InvalidRulesetForSpotlight)]
  public async Task<ApiResult<SpotlightRankings>> GetSpotlightRankingsAsync(Ruleset ruleset, int? spotlightId = null,
    CancellationToken? cancellationToken = null)
    => await GetAsync<SpotlightRankings>($"rankings/{ruleset.GetQueryName()}/charts?spotlight={spotlightId}", cancellationToken);

  /// <summary>
  /// Returns the global ranked score rankings at the specified page. One page contains 50 users.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.CountryNotFound"/></term>
  ///   <description>The country could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-ranking"/>
  /// </summary>
  /// <param name="ruleset">The ruleset in which the rankings are returned.</param>
  /// <param name="country">Optional. The country to return the rankings of. Defaults to global rankings.</param>
  /// <param name="page">Optional. The page to return.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The ranked score rankings.</returns>
  [CanReturnApiError(ApiErrorType.CountryNotFound)]
  public async Task<ApiResult<UserStatistics[]>> GetScoreRankingsAsync(Ruleset ruleset, string? country = null, int? page = null,
    CancellationToken? cancellationToken = null)
    => await GetAsync<UserStatistics[]>($"rankings/{ruleset.GetQueryName()}/score", cancellationToken, [
      ("country", country),
      ("page", page)
      ], json => json["ranking"]);

  /// <summary>
  /// Returns the global country rankings at the specified page. One page contains 50 countries.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-ranking"/>
  /// </summary>
  /// <param name="ruleset">The ruleset in which the rankings are returned.</param>
  /// <param name="page">Optional. The page to return.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The global country rankings.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<CountryStatistics[]>> GetCountryRankingsAsync(Ruleset ruleset, int? page = null, CancellationToken? cancellationToken = null)
    => await GetAsync<CountryStatistics[]>($"rankings/{ruleset.GetQueryName()}/country", cancellationToken, [("page", page)], json => json["ranking"]);

  /// <summary>
  /// Returns the global performance rankings at the specified page. One page contains 50 users.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.CountryNotFound"/></term>
  ///   <description>The country could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="UserStatistics.User"/> (including <see cref="User.Country"/> and <see cref="User.Cover"/>)</item>
  /// <item>Includes <see cref="UserStatistics.RankChangeSince30Days"/> (if no filter is applied)</item>
  /// </list>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-ranking"/>
  /// </summary>
  /// <param name="ruleset">The ruleset in which the rankings are returned.</param>
  /// <param name="country">Optional. The country to return the rankings of. Defaults to global rankings.</param>
  /// <param name="page">Optional. The page to return.</param>
  /// <param name="variant">Optional. The variant of the ruleset. Only applies to osu!mania.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The global performance rankings.</returns>
  [CanReturnApiError(ApiErrorType.CountryNotFound)]
  public async Task<ApiResult<UserStatistics[]>> GetPerformanceRankingsAsync(Ruleset ruleset, string? country = null, VariantType? variant = null,
    int? page = null, CancellationToken? cancellationToken = null)
    => await GetAsync<UserStatistics[]>($"rankings/{ruleset.GetQueryName()}/performance"
      + (variant.HasValue ? $"?variant={variant.Value.GetQueryName()}" : ""), cancellationToken, [
      ("country", country),
      ("page", page),
      ], json => json["ranking"]);
}

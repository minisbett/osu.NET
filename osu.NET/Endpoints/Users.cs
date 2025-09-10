using osu.NET.Enums;
using osu.NET.Helpers;
using osu.NET.Models.Beatmaps;
using osu.NET.Models.Events;
using osu.NET.Models.Scores;
using osu.NET.Models.Users;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#users

  /// <summary>
  /// Returns the kudosu history of the user with the specified ID.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-kudosu"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit">Optional. The amount of history entries to return.</param>
  /// <param name="offset">Optional. The offset in the history to return at.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The kudosu history entries of the user with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.UserNotFound)]
  public async Task<ApiResult<KudosuHistoryEntry[]>> GetKudosuHistoryAsync(int userId, int? limit = null, int? offset = null,
                                                                           CancellationToken? cancellationToken = null)
    => (await GetAsync<KudosuHistoryEntry[]>($"users/{userId}/kudosu", cancellationToken,
    [
      ("limit", limit),
      ("offset", offset)
    ])).WithErrorFallback(ApiErrorType.UserNotFound);

  /// <summary>
  /// Returns the scores of the specified user with the specified type in the specified ruleset, optionally excluding osu!lazer scores and fails.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-scores"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="type">The type of scores to return.</param>
  /// <param name="legacyOnly">Bool whether osu!lazer scores should be excluded. Defaults to false.</param>
  /// <param name="includeFails">Bool whether fails should be included. Defaults to false.</param>
  /// <param name="ruleset">Optional. The ruleset in which the scores are returned. Defaults to the users' preferred ruleset.</param>
  /// <param name="limit">Optional. The amount of results to return.</param>
  /// <param name="offset">Optional. The offset for the scores to return.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The scores of the specified type by the user with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.UserNotFound)]
  public async Task<ApiResult<Score[]>> GetUserScoresAsync(int userId, UserScoreType type, bool legacyOnly = false, bool includeFails = false,
                                                           Ruleset? ruleset = null, int? limit = null, int? offset = null,
                                                           CancellationToken? cancellationToken = null)
    => (await GetAsync<Score[]>($"users/{userId}/scores/{type.GetQueryName()}", cancellationToken,
    [
      ("legacy_only", legacyOnly),
      ("include_fails", includeFails),
      ("mode", ruleset),
      ("limit", limit),
      ("offset", offset)
    ])).WithErrorFallback(ApiErrorType.UserNotFound);

  /// <summary>
  /// Returns the most played beatmaps of the specified user.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit">Optional. The amount of beatmaps to limit to.</param>
  /// <param name="offset">Optional. The offset for the beatmaps returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The most played beatmaps of the user with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.UserNotFound)]
  public async Task<ApiResult<BeatmapPlaycount[]>> GetUserMostPlayedAsync(int userId, int? limit = null, int? offset = null,
                                                                          CancellationToken? cancellationToken = null)
    => (await GetAsync<BeatmapPlaycount[]>($"users/{userId}/beatmapsets/most_played", cancellationToken,
    [
      ("limit", limit),
      ("offset", offset)
    ])).WithErrorFallback(ApiErrorType.UserNotFound);

  /// <summary>
  /// Returns all beatmaps of the specified user with the specified type.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// The <see cref="BeatmapType"/> enum does not contain the most played beatmaps as the response type differs, and should
  /// thus be called via <see cref="GetUserMostPlayedAsync(int, int?, int?, CancellationToken?)"/>.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="type">The type of beatmaps to return.</param>
  /// <param name="limit"> Optional. The amount of beatmaps to limit to.</param>
  /// <param name="offset">Optional. The offset for the beatmaps returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The most played beatmaps of the user with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.UserNotFound)]
  public async Task<ApiResult<BeatmapSetExtended[]>> GetUserBeatmapsAsync(int userId, BeatmapType type, int? limit = null, int? offset = null,
                                                                          CancellationToken? cancellationToken = null)
    => (await GetAsync<BeatmapSetExtended[]>($"users/{userId}/beatmapsets/{type.GetQueryName()}", cancellationToken,
    [
      ("limit", limit),
      ("offset", offset)
    ])).WithErrorFallback(ApiErrorType.UserNotFound);

  /// <summary>
  /// Returns the recent events of the specified user.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-recent-activity"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit"> Optional. The amount of events to limit to.</param>
  /// <param name="offset">Optional. The offset for the events returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The recent events of the user with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.UserNotFound)]
  public async Task<ApiResult<Event[]>> GetRecentActivityAsync(int userId, int? limit = null, int? offset = null, CancellationToken? cancellationToken = null)
    => (await GetAsync<Event[]>($"users/{userId}/recent_activity", cancellationToken,
    [
      ("limit", limit),
      ("offset", offset)
    ])).WithErrorFallback(ApiErrorType.UserNotFound);

  /// <summary>
  /// Returns the user with the specified ID, optionally in the specified ruleset. If no ruleset is specified, the user is returned in their default ruleset.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The user with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.UserNotFound)]
  public async Task<ApiResult<UserExtended>> GetUserAsync(int userId, Ruleset? ruleset = null, CancellationToken? cancellationToken = null)
    => (await GetAsync<UserExtended>($"users/{userId}/{ruleset?.GetQueryName() ?? ""}", cancellationToken))
       .WithErrorFallback(ApiErrorType.UserNotFound);

  /// <summary>
  /// Returns the user with the specified name, optionally in the specified ruleset. If no ruleset is specified, the user is returned in their default ruleset.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.UserNotFound"/></term>
  ///   <description>The user could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user"/>
  /// </summary>
  /// <param name="username">The name of the user.</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The user with the specified name.</returns>
  [CanReturnApiError(ApiErrorType.UserNotFound)]
  public async Task<ApiResult<UserExtended>> GetUserAsync(string username, Ruleset? ruleset = null, CancellationToken? cancellationToken = null)
    => (await GetAsync<UserExtended>($"users/@{username}/{ruleset?.GetQueryName() ?? ""}", cancellationToken))
       .WithErrorFallback(ApiErrorType.UserNotFound);

  /// <summary>
  /// Returns all users with the specified IDs, up to 50. If a user ID could not be found, it is skipped.
  /// <br/><br/>
  /// This API endpoint has an increased ratelimit cost due to the inclusion of <see cref="User.RulesetStatistics"/>.<br/>
  /// If you do not need this information, use <see cref="LookupUsersAsync(int[], bool?, CancellationToken?)"/> instead.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="User.Country"/></item>
  /// <item>Includes <see cref="User.Cover"/></item>
  /// <item>Includes <see cref="User.Groups"/></item>
  /// <item>Includes <see cref="User.RulesetStatistics"/> (instead of <see cref="User.Statistics"/>)</item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-users"/>
  /// </summary>
  /// <param name="ids">The user IDs.</param>
  /// <param name="includeVariantStatistics">Optional. Bool whether osu!mania variants (<see cref="UserStatistics.Variants"/>) should be included.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The users with the specified IDs.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<User[]>> GetUsersAsync(int[] ids, bool? includeVariantStatistics = null, CancellationToken? cancellationToken = null)
    => await GetAsync<User[]>($"users", cancellationToken,
    [
      .. ids.Select(x => ("ids[]", x)),
      ("include_variant_statistics", includeVariantStatistics)
    ], json => json["users"]);

  /// <summary>
  /// Returns all users with the specified IDs, up to 50. If a user ID could not be found, it is skipped.
  /// <br/><br/>
  /// This endpoint does not include any statistics. If you need this information,
  /// use <see cref="GetUsersAsync(int[], bool?, CancellationToken?)"/> with a higher ratelimit cost.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="User.Country"/></item>
  /// <item>Includes <see cref="User.Cover"/></item>
  /// <item>Includes <see cref="User.Groups"/></item>
  /// <item>Does *not* include <see cref="User.Statistics"/> or <see cref="User.RulesetStatistics"/></item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-users"/>
  /// </summary>
  /// <param name="ids">The user IDs.</param>
  /// <param name="excludeBots">Optional. Bool whether bot users should be ignored.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The users with the specified IDs.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<User[]>> LookupUsersAsync(int[] ids, bool? excludeBots = null, CancellationToken? cancellationToken = null)
    => await GetAsync<User[]>($"users/lookup", cancellationToken,
    [
      .. ids.Select(x => ("ids[]", x)),
      ("exclude_bots", excludeBots)
    ], json => json["users"]);

  /// <summary>
  /// Returns all users with the specified IDs, up to 50. If a user ID could not be found, it is skipped.
  /// <br/><br/>
  /// This endpoint does not include any statistics. If you need this information,
  /// use <see cref="GetUsersAsync(int[], bool?, CancellationToken?)"/> with a higher ratelimit cost.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="User.Country"/></item>
  /// <item>Includes <see cref="User.Cover"/></item>
  /// <item>Includes <see cref="User.Groups"/></item>
  /// <item>Does *not* include <see cref="User.Statistics"/> or <see cref="User.RulesetStatistics"/></item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-users"/>
  /// </summary>
  /// <param name="ids">The user IDs.</param>
  /// <param name="excludeBots">Optional. Bool whether bot users should be ignored.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The users with the specified IDs.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<User[]>> LookupUsersAsync(string[] ids, bool? excludeBots = null, CancellationToken? cancellationToken = null)
    => await GetAsync<User[]>($"users/lookup", cancellationToken,
    [
      .. ids.Select(x => ("ids[]", x)),
      ("exclude_bots", excludeBots)
    ], json => json["users"]);
}

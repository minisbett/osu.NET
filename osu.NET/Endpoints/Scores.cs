using osu.NET.Enums;
using osu.NET.Helpers;
using osu.NET.Models.Scores;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#scores

  /// <summary>
  /// Returns a bundle of the most recent scores across osu! and the cursor string for fetching newer scores.
  /// <br/><br/>
  /// If <paramref name="cursor"/> is not specified, the 1000 most recent scores from oldest to newest are returned.<br/>
  /// New scores that arrived after the last request can be fetched by providing <paramref name="cursor"/>.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-scores97"/>
  /// </summary>
  /// <param name="ruleset">Optional. The ruleset to return scores of. Ignored if <paramref name="cursor"/> is specified.</param>
  /// <param name="cursor">Optional. The cursor string for fetching newer scores.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The bundle with scores.</returns>
  public async Task<ApiResult<ScoresBundle>> GetScoresAsync(Ruleset? ruleset = null, string? cursor = null, CancellationToken? cancellationToken = null)
    => await GetAsync<ScoresBundle>("scores", cancellationToken,
    [
      ("ruleset", ruleset),
      ("cursor_string", cursor)
    ]);

  /// <summary>
  /// Returns the score with the specified legacy, ruleset-specific ID in the specified ruleset.<br/>
  /// To fetch a score by its new ID, use <see cref="GetScoreAsync(long, CancellationToken?)"/>.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.ScoreNotFound"/></term>
  ///   <description>The score could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-apiv2scoresrulesetorscorescore"/>
  /// </summary>
  /// <param name="id">The legacy ID of the score.</param>
  /// <param name="ruleset">The ruleset of the score.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The score with the specified legacy ID.</returns>
  public async Task<ApiResult<Score>> GetScoreAsync(long id, Ruleset ruleset, CancellationToken? cancellationToken = null)
    => await GetAsync<Score>($"scores/{ruleset.GetQueryName()}/{id}", cancellationToken);

  /// <summary>
  /// Returns the score with the ID.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.ScoreNotFound"/></term>
  ///   <description>The score could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-apiv2scoresrulesetorscorescore"/>
  /// </summary>
  /// <param name="id">The ID of the score.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The score with the specified ID.</returns>
  public async Task<ApiResult<Score>> GetScoreAsync(long id, CancellationToken? cancellationToken = null)
    => await GetAsync<Score>($"scores/{id}", cancellationToken);
}

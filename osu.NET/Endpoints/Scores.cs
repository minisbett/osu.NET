using osu.NET.Enums;
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
}

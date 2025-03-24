using osu.NET.Helpers;
using osu.NET.Models.Other;

namespace osu.NET;

public partial class OsuApiClient
{
  /// <summary>
  /// Returns a bundle with the seasonal background of the current/last season.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-apiv2seasonal-backgrounds"/>
  /// </summary>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The bundle with the seasonal backgrounds.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<SeasonalBackgroundsBundle>> GetSeasonalBackgroundsAsync(CancellationToken? cancellationToken = null)
    => await GetAsync<SeasonalBackgroundsBundle>("seasonal-backgrounds", cancellationToken);
}

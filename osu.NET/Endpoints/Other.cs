using osu.NET.Internal;
using osu.NET.Models.Other;

namespace osu.NET;

public partial class OsuApiClient
{
  /// <summary>
  /// Returns a bundle with the seasonal background of the currently on-going or ended season.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-apiv2seasonal-backgrounds"/>
  /// </summary>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The bundle with the seasonal backgrounds.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<SeasonalBackgroundsBundle>> GetSeasonalBackgroundsAsync(CancellationToken? cancellationToken = null)
    => await GetAsync<SeasonalBackgroundsBundle>("seasonal-backgrounds", cancellationToken);

  /// <summary>
  /// Returns all available tags for beatmaps on osu!.
  /// </summary>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>All tags for beatmaps on osu!.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<Tag[]>> GetTagsAsync(CancellationToken? cancellationToken = null)
    => await GetAsync<Tag[]>("tags", cancellationToken, jsonSelector: json => json["tags"]);
}

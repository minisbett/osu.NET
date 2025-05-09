﻿using osu.NET.Helpers;
using osu.NET.Models.Beatmaps;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmapsets
  // Not implemented:
  // - https://osu.ppy.sh/docs/index.html#get-apiv2beatmapsetsbeatmapsetdownload (Lazer scope only, omitted in API wrapper)

  // TODOENDPOINT: https://osu.ppy.sh/docs/index.html#todo-documentation (undocumented) (pagination)


  /// <summary>
  /// Looksup the beatmapset that contains the beatmap with the specified ID.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.BeatmapNotFound"/></term>
  ///   <description>The beatmap could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-apiv2beatmapsetslookup"/>
  /// </summary>
  /// <param name="beatmapId">The ID of the beatmap.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The beatmapset containing the beatmap with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.BeatmapNotFound)]
  public async Task<ApiResult<BeatmapSetExtended>> LookupBeatmapSetAsync(int beatmapId, CancellationToken? cancellationToken = null)
    => await GetAsync<BeatmapSetExtended>($"beatmapsets/lookup", cancellationToken, [("beatmap_id", beatmapId)]);

  /// <summary>
  /// Returns the beatmapset with the specified ID. If the beatmapset was not found, null is returned.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.BeatmapSetNotFound"/></term>
  ///   <description>The beatmapset could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-apiv2beatmapsetsbeatmapset"/>
  /// </summary>
  /// <param name="beatmapSetId">The ID of the beatmapset.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The beatmapset with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.BeatmapSetNotFound)]
  public async Task<ApiResult<BeatmapSetExtended>> GetBeatmapSetAsync(int beatmapSetId, CancellationToken? cancellationToken = null)
    => await GetAsync<BeatmapSetExtended>($"beatmapsets/{beatmapSetId}", cancellationToken);
}

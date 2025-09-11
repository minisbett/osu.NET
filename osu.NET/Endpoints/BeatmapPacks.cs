using osu.NET.Enums;
using osu.NET.Internal;
using osu.NET.Models.Beatmaps;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmap-packs

  /// <summary>
  /// Returns a bundle of beatmap packs and the cursor string for fetching further packs. One request returns 100 beatmap packs.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-packs"/>
  /// </summary>
  /// <param name="type">Optional. The type of beatmap pack to filter for. Ignored if <paramref name="cursor"/> is specified.</param>
  /// <param name="cursor">Optional. The cursor string for fetching further beatmap packs.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The bundle with beatmap packs.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<BeatmapPacksBundle>> GetBeatmapPacksAsync(BeatmapPackType? type = null, string? cursor = null,
    CancellationToken? cancellationToken = null)
    => await GetAsync<BeatmapPacksBundle>("beatmaps/packs", cancellationToken,
    [
      ("type", type),
      ("cursor_string", cursor)
    ]);

  /// <summary>
  /// Returns the beatmap pack with the specified tag.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.BeatmapPackNotFound"/></term>
  ///   <description>The beatmap pack could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API Docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-pack"/>
  /// </summary>
  /// <param name="tag">The tag of the beatmap pack.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The beatmap pack with the specified tag.</returns>
  [CanReturnApiError(ApiErrorType.BeatmapPackNotFound)]
  public async Task<ApiResult<BeatmapPack>> GetBeatmapPackAsync(string tag, CancellationToken? cancellationToken = null)
    => await GetAsync<BeatmapPack>($"beatmaps/packs/{tag}", cancellationToken);
}

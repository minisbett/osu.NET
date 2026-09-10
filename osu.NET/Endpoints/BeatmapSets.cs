using osu.NET.Enums;
using osu.NET.Internal;
using osu.NET.Models.Beatmaps;

namespace osu.NET;

public partial class OsuApiClient
{
    // API docs: https://osu.ppy.sh/docs/index.html#beatmapsets
    // Not implemented:
    // - https://osu.ppy.sh/docs/index.html#get-apiv2beatmapsetsbeatmapsetdownload (Lazer scope only, omitted in API wrapper)

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

    /// <summary>
    /// Searches for beatmapsets with the specified search query and returns a bundle of beatmapsets and the cursor string for fetching further sets.
    /// One request returns 50 beatmapsets. The total amount of beatmapsets found is provided via <see cref="BeatmapSetsSearchBundle.Total"/>.
    /// <br/><br/>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#search-beatmapset"/>
    /// </summary>
    /// <param name="query">The sarch query for the search operation.</param>
    /// <param name="sortType">Optional. The sort order for the search results.</param>
    /// <param name="ruleset">Optional. The ruleset to filter by.</param>
    /// <param name="status">Optional. The ranked status to filter by.</param>
    /// <param name="includeNsfw">Bool whether explicit beatmapsets are included. Defaults to false.</param>
    /// <param name="includeConverts">Bool whether converted beatmapsets are included. Defaults to false.</param>
    /// <param name="onlySpotlighted">Bool whether only beatmapsets included in the beatmap spotlights are included. Defaults to false.</param>
    /// <param name="onlyFeaturedArtists">Bool whether only beatmapsets with songs from featured artists are included. Defaults to false.</param>
    /// <param name="onlyHasVideo">Bool whether only beatmapsets containing a video are included. Defaults to false.</param>
    /// <param name="onlyHasStoryboard">Bool whether only beatmapsets containing a storyboard are included. Defaults to false.</param>
    /// <param name="genreId">Optional. The ID of the genre to filter by.</param>
    /// <param name="languageId">Optional. The ID of the language to filter by.</param>
    /// <param name="page">Optional. The number of page to return.</param>
    /// <param name="cursor">Optional. The cursor string for fetching further beatmapsets.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>The bundle with beatmapsets.</returns>
    [CanReturnApiError()]
    public async Task<ApiResult<BeatmapSetsSearchBundle>> SearchBeatmapSetsAsync(string? query = null, SearchSortType? sortType = null,
        Ruleset? ruleset = null, SearchRankedStatus? status = null, bool includeNsfw = false, bool includeConverts = false, bool onlySpotlighted = false,
        bool onlyFeaturedArtists = false, bool onlyHasVideo = false, bool onlyHasStoryboard = false, int? genreId = null, int? languageId = null,
        int? page = null, string? cursor = null, CancellationToken? cancellationToken = null)
    {
        List<string> c = [];
        if (includeConverts)
            c.Add("converts");
        if (onlySpotlighted)
            c.Add("spotlights");
        if (onlyFeaturedArtists)
            c.Add("featured_artists");

        List<string> e = [];
        if (onlyHasVideo)
            e.Add("video");
        if (onlyHasStoryboard)
            e.Add("storyboard");
        
        return await GetAsync<BeatmapSetsSearchBundle>("beatmapsets/search", cancellationToken,
        [
            ("q", query),
            ("sort",  sortType),
            ("m", ruleset),
            ("s", status),
            ("nsfw", includeNsfw ? true : null),
            ("c", c.Count is 0 ? null : string.Join(".", c)),
            ("e", e.Count is 0 ? null : string.Join(".", e)),
            ("g", genreId),
            ("l",  languageId),
            ("page", page),
            ("cursor_string", cursor)
        ]);
    }
}
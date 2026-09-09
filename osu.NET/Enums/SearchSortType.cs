using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Represents the sort order used when searching for beatmapsets.<br/>
/// <br/>
/// API docs: Not documented, refere to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Libraries/Search/BeatmapsetSearchRequestParams.php"/>
/// </summary>
public enum SearchSortType
{
    /// <summary>
    /// Sort beatmaps alphabetically by artist name in ascending order.
    /// </summary>
    [QueryApiName("artist_asc")] ArtistAscending,

    /// <summary>
    /// Sort beatmaps alphabetically by artist name in descending order.
    /// </summary>
    [QueryApiName("artist_desc")] ArtistDescending,

    /// <summary>
    /// Sort beatmaps alphabetically by creator name in ascending order.
    /// </summary>
    [QueryApiName("creator_asc")] CreatorAscending,

    /// <summary>
    /// Sort beatmaps alphabetically by creator name in descending order.
    /// </summary>
    [QueryApiName("creator_desc")] CreatorDescending,

    /// <summary>
    /// Sort beatmaps by difficulty in ascending order.
    /// </summary>
    [QueryApiName("difficulty_asc")] DifficultyAscending,

    /// <summary>
    /// Sort beatmaps by difficulty in descending order.
    /// </summary>
    [QueryApiName("difficulty_desc")] DifficultyDescending,

    /// <summary>
    /// Sort beatmaps by favourite count in ascending order.
    /// </summary>
    [QueryApiName("favourites_asc")] FavouritesAscending,

    /// <summary>
    /// Sort beatmaps by favourite count in descending order.
    /// </summary>
    [QueryApiName("favourites_desc")] FavouritesDescending,

    /// <summary>
    /// Sort beatmaps by nomination count in ascending order.
    /// </summary>
    [QueryApiName("nominations_asc")] NominationsAscending,

    /// <summary>
    /// Sort beatmaps by nomination count in descending order.
    /// </summary>
    [QueryApiName("nominations_desc")] NominationsDescending,

    /// <summary>
    /// Sort beatmaps by play count in ascending order.
    /// </summary>
    [QueryApiName("plays_asc")] PlaysAscending,

    /// <summary>
    /// Sort beatmaps by play count in descending order.
    /// </summary>
    [QueryApiName("plays_desc")] PlaysDescending,

    /// <summary>
    /// Sort beatmaps by ranked date in ascending order.
    /// </summary>
    [QueryApiName("ranked_asc")] RankedAscending,

    /// <summary>
    /// Sort beatmaps by ranked date in descending order.
    /// </summary>
    [QueryApiName("ranked_desc")] RankedDescending,

    /// <summary>
    /// Sort beatmaps by rating in ascending order.
    /// </summary>
    [QueryApiName("rating_asc")] RatingAscending,

    /// <summary>
    /// Sort beatmaps by rating in descending order.
    /// </summary>
    [QueryApiName("rating_desc")] RatingDescending,

    /// <summary>
    /// Sort beatmaps by search relevance in ascending order.
    /// </summary>
    [QueryApiName("relevance_asc")] RelevanceAscending,

    /// <summary>
    /// Sort beatmaps by search relevance in descending order.
    /// </summary>
    [QueryApiName("relevance_desc")] RelevanceDescending,

    /// <summary>
    /// Sort beatmaps alphabetically by title in ascending order.
    /// </summary>
    [QueryApiName("title_asc")] TitleAscending,

    /// <summary>
    /// Sort beatmaps alphabetically by title in descending order.
    /// </summary>
    [QueryApiName("title_desc")] TitleDescending,

    /// <summary>
    /// Sort beatmaps by last update date in ascending order.
    /// </summary>
    [QueryApiName("updated_asc")] UpdatedAscending,

    /// <summary>
    /// Sort beatmaps by last update date in descending order.
    /// </summary>
    [QueryApiName("updated_desc")] UpdatedDescending
}
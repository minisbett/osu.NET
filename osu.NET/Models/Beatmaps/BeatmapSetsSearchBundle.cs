using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents a bundle containing searched-for beatmapsets and the cursor string for pagination.
/// <br/><br/>
/// API docs: Undocumented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/BeatmapsetsController.php"/>
/// </summary>
public class BeatmapSetsSearchBundle
{
    /// <summary>
    /// The beatmapsets found by the search query, up to an amount of 50.
    /// </summary>
    [JsonProperty("beatmapsets")]
    public BeatmapSetExtended[] Sets { get; init; } = default!;

    /// <summary>
    /// The cursor string for fetching further beatmapsets.
    /// </summary>
    [JsonProperty("cursor_string")]
    public string Cursor { get; init; } = default!;

    /// <summary>
    /// The total amount of beatmapsets found using the search filters.
    /// </summary>
    [JsonProperty("total")]
    public int Total { get; init; }
}
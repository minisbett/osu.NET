using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Represents the ranked status of beatmapsets when searching.<br/>
/// <br/>
/// API docs: Not documented, refere to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Libraries/Search/BeatmapsetSearchRequestParams.php"/>
/// </summary>
public enum SearchRankedStatus
{
    /// <summary>
    /// The beatmapsets can have any ranked status.
    /// </summary>
    [QueryApiName("any")] Any,
    
    /// <summary>
    /// The beatmapsets must have a persistent leaderboard (ranked, approved or loved).
    /// </summary>
    [QueryApiName("leaderboard")] HasLeaderboard,
    
    /// <summary>
    /// The beatmapsets must be ranked (including approved).
    /// </summary>
    [QueryApiName("ranked")] Ranked,
    
    /// <summary>
    /// The beatmapsets must be qualified.
    /// </summary>
    [QueryApiName("qualified")] Qualified,
    
    /// <summary>
    /// The beatmapsets must be loved.
    /// </summary>
    [QueryApiName("loved")] Loved,
    
    /// <summary>
    /// The beatmapsets must be pending.
    /// </summary>
    [QueryApiName("pending")] Pending,
    
    /// <summary>
    /// The beatmapsets must be a work in progress.
    /// </summary>
    [QueryApiName("wip")] WIP,
    
    /// <summary>
    /// The beatmapsets must be in the graveyard.
    /// </summary>
    [QueryApiName("graveyard")] Graveyard
}
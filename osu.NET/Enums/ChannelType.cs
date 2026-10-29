using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Channel type
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#channeltype"/><br/>
/// Source: <a hreh="https://github.com/ppy/osu-web/blob/master/app/Models/Chat/Channel.php#L75-L85"/>
/// </summary>
public enum ChannelType
{
    /// <summary>
    /// Indicates a public channel.
    /// </summary>
    [JsonApiName("PUBLIC")] Public,

    /// <summary>
    /// Indicates a private channel.
    /// </summary>
    [JsonApiName("PRIVATE")] Private,

    /// <summary>
    /// Indicates a multiplayer channel.
    /// </summary>
    [JsonApiName("MULTIPLAYER")] Multiplayer,

    /// <summary>
    /// Indicates a spectator channel.
    /// </summary>
    [JsonApiName("SPECTATOR")] Spectator,

    /// <summary>
    /// Indicates a temporary channel (deprecated).
    /// </summary>
    [JsonApiName("TEMPORARY")] Temporary,

    /// <summary>
    /// Indicates a PM channel.
    /// </summary>
    [JsonApiName("PM")] PM,

    /// <summary>
    /// Indicates a group channel.
    /// </summary>
    [JsonApiName("GROUP")] Group,

    /// <summary>
    /// Indicates an Announce channel.
    /// </summary>
    [JsonApiName("ANNOUNCE")] Announce,

    /// <summary>
    /// Indicates a Team channel.
    /// </summary>
    [JsonApiName("TEAM")] Team,
}
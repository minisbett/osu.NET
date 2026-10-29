using Newtonsoft.Json;
using osu.NET.Models.Users;

namespace osu.NET.Models.Chat;

/// <summary>
/// Represents the response of a Get Channel request.
/// <br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-channel"/> (response)<br/>
/// Source: todo ?
/// </summary>
public class GetChannelResponse
{
    /// <summary>
    /// The channel
    /// </summary>
    [JsonProperty("channel")]
    public ChatChannel Channel { get; init; } = default!;

    /// <summary>
    /// An array of the users in the channel (only for PM channels).
    /// </summary>
    [JsonProperty("users")]
    public User[]? Users { get; init; }
}
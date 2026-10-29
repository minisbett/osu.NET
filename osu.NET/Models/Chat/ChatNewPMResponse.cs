using Newtonsoft.Json;

namespace osu.NET.Models.Chat;

/// <summary>
/// Represents the response returned when creating a new private message (PM).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#create-new-pm"/> (response)<br/>
/// Source: todo ?
/// </summary>
public class ChatNewPMResponse
{
    /// <summary>
    /// The new <see cref="ChatChannel"/>
    /// </summary>
    [JsonProperty("channel")]
    public ChatChannel Channel { get; init; } = default!;

    /// <summary>
    /// The sent <see cref="ChatMessage"/>
    /// </summary>
    [JsonProperty("message")]
    public ChatMessage Message { get; init; } = default!;

    /// <summary>
    /// Deprecated, use <see cref="ChatChannel.ChannelId"/> from <see cref="Channel"/>. <c>channel_id</c> of newly created <see cref="ChatChannel"/>,
    /// </summary>
    [JsonProperty("new_channel_id")]
    public long NewChannelId { get; init; }
}
using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Chat;

/// <summary>
/// Represents an individual chat "channel" in the game.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#chatchannel"/><br/>
/// Source: todo ?
/// </summary>
public class ChatChannel
{
    /// <summary>
    /// The ID of the channel.
    /// </summary>
    [JsonProperty("channel_id")]
    public long ChannelId { get; init; }

    /// <summary>
    /// The name of the channel.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; init; } = default!;

    /// <summary>
    /// The description of the channel
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }

    /// <summary>
    /// The display icon of the channel.
    /// </summary>
    [JsonProperty("icon")]
    public string? Icon { get; init; }

    /// <summary>
    /// The type of the channel.
    /// </summary>
    [JsonProperty("type")]
    public ChannelType Type { get; init; }

    /// <summary>
    /// The length limit of the message.
    /// </summary>
    [JsonProperty("message_length_limit")]
    public int MessageLengthLimit { get; init; }

    /// <summary>
    /// Bool whether the user can't send message.
    /// </summary>
    [JsonProperty("moderated")]
    public bool Moderated { get; init; }

    /// <summary>
    /// The UUID from requests that is relayed back to the sender.
    /// </summary>
    [JsonProperty("uuid")]
    public string? UUID { get; init; }

    /// <summary>
    /// The <see cref="ChatChannelUserAttributes"/> (only present on some responses).
    /// </summary>
    [JsonProperty("current_user_attributes")]
    public ChatChannelUserAttributes? CurrentUserAttributes { get; init; }

    /// <summary>
    /// Deprecated. Use <c>CurrentUserAttributes.LastReadId</c>.
    /// </summary>
    [JsonProperty("last_read_id")]
    public long? LastReadId { get; init; }

    /// <summary>
    /// The <c>message_id</c> of the last known message (only returned in presence responses).
    /// </summary>
    [JsonProperty("last_message_id")]
    public long? LastMessageId { get; init; }

    /// <summary>
    /// Deprecated. An array of the recents messages, up to 50 most recent.
    /// </summary>
    [JsonProperty("recent_messages")]
    public ChatMessage[]? RecentMessages { get; init; }

    /// <summary>
    /// An array of <c>user_id</c> that are in the channel (not included for PUBLIC channels).
    /// </summary>
    [JsonProperty("users")]
    public int[]? Users { get; init; }
}
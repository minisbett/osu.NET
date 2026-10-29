using Newtonsoft.Json;
using osu.NET.Enums;
using osu.NET.Models.Users;

namespace osu.NET.Models.Chat;

/// <summary>
/// Represents an individual Message within a <see cref="ChatChannel"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#chatmessage"/><br/>
/// Source: todo ?
/// </summary>
public class ChatMessage
{
    /// <summary>
    /// The <see cref="ChatChannel"/> id of where the message was sent.
    /// </summary>
    [JsonProperty("channel_id")]
    public long ChannelId { get; init; }

    /// <summary>
    /// The content of the message.
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; init; } = default!;

    /// <summary>
    /// Bool whether the message is an action. For example, the message "/me dances" is considered an action.
    /// </summary>
    [JsonProperty("is_action")]
    public bool IsAction { get; init; }

    /// <summary>
    /// The unique id of the message.
    /// </summary>
    [JsonProperty("message_id")]
    public long MessageId { get; init; }

    /// <summary>
    /// The <c>user_id</c> of the sender.
    /// </summary>
    [JsonProperty("sender_id")]
    public int SenderId { get; init; }

    /// <summary>
    /// The date/time when the message was sent.
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTimeOffset Timestamp { get; init; }

    /// <summary>
    /// The type of message
    /// </summary>
    [JsonProperty("type")]
    public MessageType Type { get; init; }

    /// <summary>
    /// The message identifier originally sent by client.
    /// </summary>
    [JsonProperty("uuid")]
    public string? UUID { get; init; }

    /// <summary>
    /// Embedded User object to save additional api lookups.
    /// </summary>
    [JsonProperty("sender")]
    public User? Sender { get; init; }
}
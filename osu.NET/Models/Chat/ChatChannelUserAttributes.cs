using Newtonsoft.Json;

namespace osu.NET.Models.Chat;

/// <summary>
/// An object listing various related permissions and states for the current user, related to the object it is attached to.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#currentuserattributes"/><br/>
/// Source: todo ?
/// </summary>
public class ChatChannelUserAttributes
{
    /// <summary>
    /// Can send messages to this channel.
    /// </summary>
    [JsonProperty("can_message")]
    public bool CanMessage;

    /// <summary>
    /// Reason messages cannot be sent to this channel
    /// </summary>
    [JsonProperty("can_message_error")]
    public string? CanMessageError;

    /// <summary>
    /// <c>message_id</c> of last message read.
    /// </summary>
    [JsonProperty("last_read_id")]
    public long LastReadId;

}
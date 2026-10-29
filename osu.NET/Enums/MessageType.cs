using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Represents the type of message of a <see cref="osu.NET.Models.Chat.ChatMessage"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#chatmessage"/><br/>
/// Source: todo ?
/// </summary>
public enum MessageType
{
    /// <summary>
    /// Represents an Action type of message
    /// </summary>
    [JsonApiName("action")] Action,

    /// <summary>
    /// Represents a Markdown type of message
    /// </summary>
    [JsonApiName("markdown")] Markdown,

    /// <summary>
    /// Represents a Plain type of message
    /// </summary>
    [JsonApiName("plain")] Plain
}
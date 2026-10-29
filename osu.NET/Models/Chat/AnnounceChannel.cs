using Newtonsoft.Json;

namespace osu.NET.Models.Chat;

/// <summary>
/// Announce channel details
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#create-channel"/> (channel body parameter)<br/>
/// Source: todo ?
/// </summary>
public class AnnounceChannel
{
    /// <summary>
    /// The channel name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; init; } = default!;

    /// <summary>
    /// The channel description
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; init; } = default!;
}
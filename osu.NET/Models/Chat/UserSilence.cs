using Newtonsoft.Json;

namespace osu.NET.Models.Chat;

/// <summary>
/// A record indicating a User was silenced.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#usersilence"/><br/>
/// Source: todo ?
/// </summary>
public class UserSilence
{
    /// <summary>
    /// id of this object.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; init; }

    /// <summary>
    /// id of the User that was silenced
    /// </summary>
    [JsonProperty("user_id")]
    public int UserId { get; init; }
}
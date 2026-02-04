using Newtonsoft.Json;

namespace osu.NET.Models.Events;

/// <summary>
/// Represents the event when a user changes their username.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class UsernameChangeEvent : Event
{
  /// <summary>
  /// The user who changed their username, including <see cref="EventUser.PreviousUsername"/>.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; init; } = default!;
}

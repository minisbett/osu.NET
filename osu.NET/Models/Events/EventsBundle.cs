using Newtonsoft.Json;

namespace osu.NET.Models.Events;

/// <summary>
/// Represents a bundle containing events and the cursor string for pagination.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-events"/> (response)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/EventsController.php"/>
/// </summary>
public class EventsBundle
{
  /// <summary>
  /// The events.
  /// </summary>
  [JsonProperty("events")]
  public Event[] Events { get; init; } = default!;

  /// <summary>
  /// The cursor string for fetching further events.
  /// </summary>
  [JsonProperty("cursor_string")]
  public string Cursor { get; init; } = default!;
}

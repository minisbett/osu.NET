using Newtonsoft.Json;
using osu.NET.Models.Beatmaps.Discussions;

namespace osu.NET.Models.Beatmaps.Events;

/// <summary>
/// The base class for the events of a beatmapset.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-event-json.ts"/>
/// </summary>
public class BeatmapSetEvent
{
  /// <summary>
  /// </summary>
  [JsonProperty("beatmapset")]
  public BeatmapSet Set { get; private set; } = default!;

  /// <summary>
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// </summary>
  [JsonProperty("discussion")]
  public Discussion Discussion { get; private set; } = null!;

  /// <summary>
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; private set; }
}

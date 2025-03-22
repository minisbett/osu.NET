using Newtonsoft.Json;

namespace osu.NET.Models.Matches;

/// <summary>
/// Represents an event in a match.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#matchevent"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/LegacyMatch/EventTransformer.php"/>
/// </summary>
public class MatchEvent
{
  /// <summary>
  /// The ID of this event.
  /// </summary>
  [JsonProperty("id")]
  public long Id { get; private set; }

  /// <summary>
  /// the detials about this event (type and message).
  /// </summary>
  [JsonProperty("detail")]
  public MatchEventDetails Details { get; private set; } = default!;

  /// <summary>
  /// The datetime at which this event occurred.
  /// </summary>
  [JsonProperty("timestamp")]
  public DateTimeOffset Timestamp { get; private set; }

  /// <summary>
  /// The ID of the user this event is related to. This will be null if this event is not related to a user.
  /// </summary>
  [JsonProperty("user_id")]
  public int? UserId { get; private set; }

  /// <summary>
  /// The match game associated with this event. This will be null if this event is not related to a match game.
  /// </summary>
  [JsonProperty("game")]
  public MatchGame? Game { get; private set; }
}

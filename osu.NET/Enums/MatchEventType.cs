using osu.NET.Internal;
using osu.NET.Models.Matches;

namespace osu.NET.Enums;

/// <summary>
/// Represents the type of a <see cref="MatchEvent"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#match-event-type-navigation"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/LegacyMatch/Event.php"/>
/// </summary>
public enum MatchEventType
{
  /// <summary>
  /// A player left the match.
  /// </summary>
  [JsonApiName("player-left")]
  PlayerLeft,

  /// <summary>
  /// A player joined the match.
  /// </summary>
  [JsonApiName("player-joined")]
  PlayerJoined,

  /// <summary>
  /// A player was kicked from the match.
  /// </summary>
  [JsonApiName("player-kicked")]
  PlayerKicked,

  /// <summary>
  /// The match was created.
  /// </summary>
  [JsonApiName("match-created")]
  MatchCreated,

  /// <summary>
  /// The match was disbanded.
  /// </summary>
  [JsonApiName("match-disbanded")]
  MatchDisbanded,

  /// <summary>
  /// The host of the match was changed.
  /// </summary>
  [JsonApiName("host-changed")]
  HostChanged,

  /// <summary>
  /// The match event has a custom message.
  /// </summary>
  [JsonApiName("other")]
  Other
}

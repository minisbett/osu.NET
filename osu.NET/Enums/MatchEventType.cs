using osu.NET.Helpers;
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
  [JsonAPIName("player-left")]
  PlayerLeft,

  /// <summary>
  /// A player joined the match.
  /// </summary>
  [JsonAPIName("player-joined")]
  PlayerJoined,

  /// <summary>
  /// A player was kicked from the match.
  /// </summary>
  [JsonAPIName("player-kicked")]
  PlayerKicked,

  /// <summary>
  /// The match was created.
  /// </summary>
  [JsonAPIName("match-created")]
  MatchCreated,

  /// <summary>
  /// The match was disbanded.
  /// </summary>
  [JsonAPIName("match-disbanded")]
  MatchDisbanded,

  /// <summary>
  /// The host of the match was changed.
  /// </summary>
  [JsonAPIName("host-changed")]
  HostChanged,

  /// <summary>
  /// The match event has a custom message.
  /// </summary>
  [JsonAPIName("other")]
  Other
}

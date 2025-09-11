using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Represents the team types for legacy multiplayer matches (head-to-head, tag-coop, ...).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#matchgame"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/LegacyMatch/Game.php"/>
/// </summary>
public enum MatchTeamType
{
  /// <summary>
  /// Each player plays individually, head-to-head.
  /// </summary>
  [JsonApiName("head-to-head")]
  HeadToHead,

  /// <summary>
  /// All players are playing TAG in a team.
  /// </summary>
  [JsonApiName("tag-coop")]
  TagCoop,

  /// <summary>
  /// The players are playing in two teams against each other.
  /// </summary>
  [JsonApiName("team-vs")]
  TeamVs,

  /// <summary>
  /// The players are playing TAG in two teams against each other.
  /// </summary>
  [JsonApiName("tag-team-vs")]
  TagTeamVs,
}

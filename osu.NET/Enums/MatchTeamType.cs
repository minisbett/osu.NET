using osu.NET.Helpers;

namespace osu.NET.Enums;

public enum MatchTeamType
{
  /// <summary>
  /// Each player plays individually, head-to-head.
  /// </summary>
  [JsonAPIName("head-to-head")]
  HeadToHead,

  /// <summary>
  /// All players are playing TAG in a team.
  /// </summary>
  [JsonAPIName("tag-coop")]
  TagCoop,

  /// <summary>
  /// The players are playing in two teams against each other.
  /// </summary>
  [JsonAPIName("team-vs")]
  TeamVs,

  /// <summary>
  /// The players are playing TAG in two teams against each other.
  /// </summary>
  [JsonAPIName("tag-team-vs")]
  TagTeamVs,
}

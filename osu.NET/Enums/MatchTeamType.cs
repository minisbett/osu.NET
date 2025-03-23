using osu.NET.Helpers;

namespace osu.NET.Enums;

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

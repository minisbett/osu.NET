using Newtonsoft.Json;

namespace osu.NET.Models.Matches;

/// <summary>
/// Represents a legacy multiplayer match in osu!stable.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#match"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/LegacyMatch/LegacyMatchTransformer.php"/>
/// </summary>
public class Match
{
  /// <summary>
  /// The ID of this match.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; init; }

  /// <summary>
  /// The datetime at which this match was started.
  /// </summary>
  [JsonProperty("start_time")]
  public DateTimeOffset StartedAt { get; init; }

  /// <summary>
  /// The datetime at which this match was ended. This will be null if the match is still ongoing.
  /// </summary>
  [JsonProperty("end_time")]
  public DateTimeOffset? EndedAt { get; init; }

  /// <summary>
  /// The name of this match.
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; init; } = default!;
}

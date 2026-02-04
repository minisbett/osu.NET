using Newtonsoft.Json;
using osu.NET.Models.Users;

namespace osu.NET.Models.Matches;

/// <summary>
/// Represents a bundle containing a match and its events and related users.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-match"/> (response)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/MatchesController.php"/>
/// </summary>
public class MatchBundle
{
  /// <summary>
  /// The match.
  /// </summary>
  [JsonProperty("match")]
  public Match Match { get; init; } = default!;

  /// <summary>
  /// The events in the match.
  /// </summary>
  [JsonProperty("events")]
  public MatchEvent[] Events { get; init; } = default!;

  /// <summary>
  /// The users related to the match.
  /// </summary>
  [JsonProperty("users")]
  public User[] Users { get; init; } = default!;

  /// <summary>
  /// The ID of the first event in the match.
  /// </summary>
  [JsonProperty("first_event_id")]
  public long FirstEventId { get; init; }

  /// <summary>
  /// The ID of the latest event in the match.
  /// </summary>
  [JsonProperty("latest_event_id")]
  public long LatestEventId { get; init; }
}

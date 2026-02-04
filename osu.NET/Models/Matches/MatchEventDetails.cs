using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Matches;

/// <summary>
/// Represents the details of a <see cref="MatchEvent"/> (type and message).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#matchevent"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/LegacyMatch/Event.php"/>
/// </summary>
public class MatchEventDetails
{
  /// <summary>
  /// The type of the match event.
  /// </summary>
  [JsonProperty("type")]
  public MatchEventType Type { get; init; }

  /// <summary>
  /// The text of the match event. This will be null if <see cref="Type"/> is not <see cref="MatchEventType.Other"/>.
  /// </summary>
  [JsonProperty("text")]
  public string? Text { get; init; }
}

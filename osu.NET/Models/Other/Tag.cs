using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Other;

/// <summary>
/// Represents a tag for a beatmap.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/Tag.php"/>
/// </summary>
public class Tag
{
  /// <summary>
  /// The ID of this tag.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; init; }

  /// <summary>
  /// The name of this tag.
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; init; } = default!;

  /// <summary>
  /// The ruleset in which this tag is used. This will be null if the tag is not ruleset-specific.
  /// </summary>
  [JsonProperty("ruleset_id")]
  public Ruleset? Ruleset { get; init; } = default!;

  /// <summary>
  /// the description of this tag.
  /// </summary>
  [JsonProperty("description")]
  public string Description { get; init; } = default!;
}

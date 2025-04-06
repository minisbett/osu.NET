using Newtonsoft.Json;
using osu.NET.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
  public int Id { get; private set; }

  /// <summary>
  /// The name of this tag.
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; private set; } = default!;

  /// <summary>
  /// The ruleset in which this tag is used. This will be null if the tag is not ruleset-specific.
  /// </summary>
  [JsonProperty("ruleset_id")]
  public Ruleset? Ruleset { get; private set; } = default!;

  /// <summary>
  /// the description of this tag.
  /// </summary>
  [JsonProperty("description")]
  public string Description { get; private set; } = default!;
}

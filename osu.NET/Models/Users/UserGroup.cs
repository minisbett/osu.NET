using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents a group a user can be in.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#usergroup"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-group-json.ts"/>
/// </summary>
public class UserGroup
{
  /// <summary>
  /// The hex colour of this group. This will be null if the group has no special colour.
  /// </summary>
  [JsonProperty("colour")]
  public string? Colour { get; init; }

  /// <summary>
  /// The description of this group. This will be null if there is no description set.
  /// </summary>
  [JsonProperty("description")]
  public GroupDescription? Description { get; init; }

  /// <summary>
  /// DOCS: what is this?
  /// </summary>
  [JsonProperty("has_listing")]
  public bool HasListing { get; init; }

  /// <summary>
  /// Bool whether this group is specific to certain rulesets. If <see langword="false"/>, <see cref="PlayModes"/> will be null.
  /// </summary>
  [JsonProperty("has_playmodes")]
  public bool HasPlaymodes { get; init; }

  /// <summary>
  /// The ID of this group.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; init; }

  /// <summary>
  /// The string identifier of this group.
  /// </summary>
  [JsonProperty("identifier")]
  public string Identifier { get; init; } = default!;

  /// <summary>
  /// Bool whether this group is a probationary group (e.g. probationary beatmap nominators).
  /// </summary>
  [JsonProperty("is_probationary")]
  public bool IsProbationary { get; init; }

  /// <summary>
  /// The name of this group.
  /// </summary>
  [JsonProperty("name")]
  public string Name { get; init; } = default!;

  /// <summary>
  /// The short name of this group.
  /// </summary>
  [JsonProperty("short_name")]
  public string ShortName { get; init; } = default!;

  /// <summary>
  /// The rulesets this group is specific to.
  /// This will be null if <see cref="HasPlaymodes"/> is <see langword="false"/>, and the group therefore counts independent of rulesets.
  /// </summary>
  [JsonProperty("playmodes")]
  public Ruleset[]? PlayModes { get; init; } = default!;
}
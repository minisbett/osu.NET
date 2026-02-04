using Newtonsoft.Json;
using osu.NET.Enums;
using osu.NET.Models.Users;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents a beatmap.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmap"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmap-json.ts"/>
/// </summary>
public class Beatmap
{
  #region Default Attributes

  /// <summary>
  /// The ID of the beatmapset this beatmap belongs to.
  /// </summary>
  [JsonProperty("beatmapset_id")]
  public int SetId { get; init; }

  /// <summary>
  /// The difficulty rating of this beatmap.
  /// </summary>
  [JsonProperty("difficulty_rating")]
  public float DifficultyRating { get; init; }

  /// <summary>
  /// The ID of this beatmap.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; init; }

  /// <summary>
  /// The ruleset this beatmap was made for.
  /// </summary>
  [JsonProperty("mode")]
  public Ruleset Ruleset { get; init; }

  /// <summary>
  /// The ranked status of this beatmap.
  /// </summary>
  [JsonProperty("status")]
  public RankedStatus Status { get; init; }

  /// <summary>
  /// The total length of this beatmap, in seconds.
  /// </summary>
  [JsonProperty("total_length")]
  private int _totalLengthSeconds;

  /// <summary>
  /// The total length of this beatmap.
  /// </summary>
  public TimeSpan TotalLength => TimeSpan.FromSeconds(_totalLengthSeconds);

  /// <summary>
  /// The user ID of the creator of this beatmap.
  /// </summary>
  [JsonProperty("user_id")]
  public int UserId { get; init; }

  /// <summary>
  /// The difficulty name of this beatmap.
  /// </summary>
  [JsonProperty("version")]
  public string Version { get; init; } = default!;

  #endregion

  #region Available Attributes

  /// <summary>
  /// The beatmapset this beatmap belongs to. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("beatmapset")]
  public BeatmapSet? Set { get; internal set; }

  /// <summary>
  /// The MD5 checksum of the .osu file of this beatmap. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("checksum")]
  public string? Checksum { get; init; }

  /// <summary>
  /// The amount of times players have exited of failed the beatmap at a certain percentage. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("failtimes")]
  public Failtimes? Failtimes { get; init; }

  /// <summary>
  /// The maximum achievable combo on this beatmap. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("max_combo")]
  public int? MaxCombo { get; init; }

  /// <summary>
  /// The owners of the beatmap. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("owners")]
  public BeatmapOwner[]? Owners { get; init; }

  /// <summary>
  /// The top-voted tags of the beatmap. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("top_tag_ids")]
  public TopTag[]? TopTags { get; init; }

  /// <summary>
  /// The creator of this beatmap. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("user")]
  public User? Creator { get; init; }

  #endregion
}
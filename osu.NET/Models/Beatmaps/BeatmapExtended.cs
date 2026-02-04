using Newtonsoft.Json;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents an extended beatmap, inheriting from <see cref="Beatmap"/> and including additional properties.
/// The API differs between "normal" beatmaps and "extended" beatmaps, as not all information is available on all endpoints.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapextended"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmap-extended-json.ts"/>
/// </summary>
public class BeatmapExtended : Beatmap
{
  /// <summary>
  /// The overall difficulty (OD) of this beatmap.
  /// </summary>
  [JsonProperty("accuracy")]
  public float OverallDifficulty { get; init; }

  /// <summary>
  /// The approach rate (AR) of this beatmap.
  /// </summary>
  [JsonProperty("ar")]
  public float ApproachRate { get; init; }

  /// <summary>
  /// The beats per minute (BPM) of this beatmap.
  /// </summary>
  [JsonProperty("bpm")]
  public float BPM { get; init; }

  /// <summary>
  /// Bool whether this beatmap is converted from a different ruleset or not. This may be null.
  /// </summary>
  [JsonProperty("convert")]
  public bool? IsConverted { get; init; }

  /// <summary>
  /// The amount of circles in this beatmap.
  /// </summary>
  [JsonProperty("count_circles")]
  public int CountCircles { get; init; }

  /// <summary>
  /// The amount of sliders in this beatmap.
  /// </summary>
  [JsonProperty("count_sliders")]
  public int CountSliders { get; init; }

  /// <summary>
  /// The amount of spinners in this beatmap.
  /// </summary>
  [JsonProperty("count_spinners")]
  public int CountSpinners { get; init; }

  /// <summary>
  /// The circle size (CS) of this beatmap.
  /// </summary>
  [JsonProperty("cs")]
  public float CircleSize { get; init; }

  /// <summary>
  /// The datetime at which this beatmap was deleted. This will be null if the beatmap has not been deleted.
  /// </summary>
  [JsonProperty("deleted_at")]
  public DateTimeOffset? DeletedAt { get; init; }

  /// <summary>
  /// The health drain rate (HP) of this beatmap.
  /// </summary>
  [JsonProperty("drain")]
  public float HealthDrain { get; init; }

  /// <summary>
  /// The hit length of this beatmap, in seconds.
  /// </summary>
  [JsonProperty("hit_length")]
  private int _hitLengthSeconds;

  /// <summary>
  /// The hit length of this beatmap.
  /// </summary>
  public TimeSpan HitLength => TimeSpan.FromSeconds(_hitLengthSeconds);

  /// <summary>
  /// Bool whether scores on this beatmap are persistent (beatmap is ranked, qualified, approved or loved).
  /// </summary>
  [JsonProperty("is_scoreable")]
  public bool IsScoreable { get; init; }

  /// <summary>
  /// The datetime at which this beatmap was last updated.
  /// </summary>
  [JsonProperty("last_updated")]
  public DateTimeOffset LastUpdated { get; init; }

  /// <summary>
  /// The amount of passes this beatmap has.
  /// </summary>
  [JsonProperty("passcount")]
  public int PassCount { get; init; }

  /// <summary>
  /// The amount of plays this beatmap has.
  /// </summary>
  [JsonProperty("playcount")]
  public int PlayCount { get; init; }

  /// <summary>
  /// The URL to the beatmap page of this beatmap.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; init; } = default!;

  private BeatmapSetExtended? _beatmapSet;

  /// <summary>
  /// The beatmapset this beatmap belongs to. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("beatmapset")]
  public new BeatmapSetExtended? Set
  {
    get => _beatmapSet;
    private set
    {
      _beatmapSet = value;
      base.Set = value;
    }
  }
}
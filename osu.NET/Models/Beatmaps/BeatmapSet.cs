using Newtonsoft.Json;
using osu.NET.Enums;
using osu.NET.Models.Beatmaps.Discussions;
using osu.NET.Models.Beatmaps.Events;
using osu.NET.Models.Users;

namespace osu.NET.Models.Beatmaps;

/// <summary>
/// Represents a beatmapset.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapset"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public class BeatmapSet
{
  // NOTE: The "nominations" attribute does not seem to be returned by the API
  //       Code: https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts#L57

  #region Default Attributes

  /// <summary>
  /// The artist of the song of this beatmapset.
  /// </summary>
  [JsonProperty("artist")]
  public string Artist { get; init; } = default!;

  /// <summary>
  /// The unicode representation of the artist of the song of this beatmapset.
  /// </summary>
  [JsonProperty("artist_unicode")]
  public string ArtistUnicode { get; init; } = default!;

  /// <summary>
  /// The URLs for the cover texture assets of this beatmapset.
  /// </summary>
  [JsonProperty("covers")]
  public BeatmapSetCovers Covers { get; init; } = default!;

  /// <summary>
  /// The name of the creator of this beatmapset.
  /// </summary>
  [JsonProperty("creator")]
  public string CreatorName { get; init; } = default!;

  /// <summary>
  /// The amount of favourites this beatmapset has.
  /// </summary>
  [JsonProperty("favorite_count")]
  public int FavouriteCount { get; init; }

  /// <summary>
  /// Info about the hype progress of this beatmapset.
  /// </summary>
  [JsonProperty("hype")]
  public Hypes Hypes { get; init; } = default!;

  /// <summary>
  /// The ID of this beatmapset.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; init; }

  /// <summary>
  /// Bool whether this beatmapset contains explicit content.
  /// </summary>
  [JsonProperty("nsfw")]
  public bool IsNsfw { get; init; }

  /// <summary>
  /// The global milliseconds offset for the audio of this beatmapset.
  /// </summary>
  [JsonProperty("offset")]
  public int Offset { get; init; }

  /// <summary>
  /// The amount of plays this beatmapset has.
  /// </summary>
  [JsonProperty("play_count")]
  public int PlayCount { get; init; }

  /// <summary>
  /// The URL for the audio preview of this beatmapset.
  /// </summary>
  [JsonProperty("preview_url")]
  public string PreviewUrl { get; init; } = default!;

  /// <summary>
  /// The source of the song of this beatmapset.
  /// </summary>
  [JsonProperty("source")]
  public string Source { get; init; } = default!;

  /// <summary>
  /// Bool whether this beatmapset is spotlighted.
  /// </summary>
  [JsonProperty("spotlight")]
  public bool IsSpotlighted { get; init; }

  /// <summary>
  /// The ranked status of this beatmapset.
  /// </summary>
  [JsonProperty("status")]
  public RankedStatus Status { get; init; }

  /// <summary>
  /// The title of the song of this beatmapset.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; init; } = default!;

  /// <summary>
  /// The unicode representation of the title of the song of this beatmapset.
  /// </summary>
  [JsonProperty("title_unicode")]
  public string TitleUnicode { get; init; } = default!;

  /// <summary>
  /// The ID of the sound track in the featured artist program. This will be null if the song is not a part of it.
  /// </summary>
  [JsonProperty("track_id")]
  public int? TrackId { get; init; }

  /// <summary>
  /// The user ID of the creator of this beatmapset.
  /// </summary>
  [JsonProperty("user_id")]
  public int CreatorId { get; init; }

  /// <summary>
  /// Bool whether this beatmapset contains a background video.
  /// </summary>
  [JsonProperty("video")]
  public bool HasVideo { get; init; }

  /// <summary>
  /// The tags of the beatmap packs in which this beatmapset is included. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("pack_tags")]
  public string[] PackTags { get; init; } = default!;

  #endregion

  #region Available Attributes

  /// <summary>
  /// Info about the availability of this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("availability")]
  public Availability? Availability { get; init; }

  /// <summary>
  /// The beatmaps belonging to this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("beatmaps")]
  public Beatmap[]? Beatmaps { get; internal set; }

  /// <summary>
  /// The mode-converted version of the beatmaps belonging to this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("converts")]
  public BeatmapExtended[]? Converts { get; init; }

  /// <summary>
  /// The nominations on this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("current_nominations")]
  public Nomination[]? CurrentNominations { get; init; }

  /// <summary>
  /// The description of this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("description")]
  public BeatmapSetDescription? Description { get; init; }

  /// <summary>
  /// The discussions on this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("discussions")]
  public Discussion[]? Discussions { get; init; }

  /// <summary>
  /// The eligible main rulesets for this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("eligible_main_rulesets")]
  public Ruleset[] Rulesets { get; init; } = default!;

  /// <summary>
  /// The events of this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("events")]
  public BeatmapSetEvent[]? Events { get; init; }

  /// <summary>
  /// The genre of the song of this beatmapset. This will be null if the genre was not set by the creator.
  /// </summary>
  [JsonProperty("genre")]
  public Genre? Genre { get; init; }

  /// <summary>
  /// The language of the song of this beatmapset. This will be null if the language was not set by the creator.
  /// </summary>
  [JsonProperty("language")]
  public Language? Language { get; init; }

  /// <summary>
  /// A 11-element array representing the the amount of ratings of this beatmapset for all ratings between 0-10. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("ratings")]
  public int[]? Ratings { get; init; }

  /// <summary>
  /// The (up to) 50 users that most recently favourited this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("recent_favourites")]
  public User[]? RecentFavourites { get; init; }

  /// <summary>
  /// All users related to this beatmapset (main creator, guest difficulty creators, nominators). This is an optional property and may be null.
  /// </summary>
  [JsonProperty("related_users")]
  public User[]? RelatedUsers { get; init; }

  /// <summary>
  /// The user that created this beatmapset. This is an optional property and may be null.
  /// </summary>
  [JsonProperty("user")]
  public User? Creator { get; init; }

  #endregion
}

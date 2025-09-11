using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Represents the type of an event (the "Recent" section on osu! profiles).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public enum EventType
{
  /// <summary>
  /// Represents the event when a user obtained an achievement.
  /// </summary>
  [JsonApiName("achievement")]
  Achievement,

  /// <summary>
  /// Represents the event when a user played a beatmap a certain number of times.
  /// </summary>
  [JsonApiName("beatmapPlaycount")]
  BeatmapPlaycount,

  /// <summary>
  /// Represents the event when a beatmap of a user changes the state to ranked, approved, qualified or loved.
  /// </summary>
  [JsonApiName("beatmapsetApprove")]
  BeatmapsetApprove,

  /// <summary>
  /// Represents the event when a user deletes a beatmapset.
  /// </summary>
  [JsonApiName("beatmapsetDelete")]
  BeatmapsetDelete,

  /// <summary>
  /// Represents the event when a user updates a beatmapset in the graveyard.
  /// </summary>
  [JsonApiName("beatmapsetRevive")]
  BeatmapsetRevive,

  /// <summary>
  /// Represents the event when a user updates a beatmapset.
  /// </summary>
  [JsonApiName("beatmapsetUpdate")]
  BeatmapsetUpdate,

  /// <summary>
  /// Represents the event when a user uploads a new beatmapset.
  /// </summary>
  [JsonApiName("beatmapsetUpload")]
  BeatmapsetUpload,

  /// <summary>
  /// Represents the event when a user achieves a certain rank on a beatmap.
  /// </summary>
  [JsonApiName("rank")]
  Rank,

  /// <summary>
  /// Represents the event when a user loses first place to another user.
  /// </summary>
  [JsonApiName("rankLost")]
  RankLost,

  /// <summary>
  /// Represents the event when a user changes their username.
  /// </summary>
  [JsonApiName("usernameChange")]
  UsernameChange,

  /// <summary>
  /// Represents the event when a user supports osu! for the second time and onwards.
  /// </summary>
  [JsonApiName("userSupportAgain")]
  UserSupportAgain,

  /// <summary>
  /// Represents the event when a user supports osu! for the first time.
  /// </summary>
  [JsonApiName("userSupportFirst")]
  UserSupportFirst,

  /// <summary>
  /// Represents the event when a user is gifted a supporter tag by another user.
  /// </summary>
  [JsonApiName("userSupportGift")]
  UserSupportGift
}

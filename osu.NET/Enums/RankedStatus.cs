using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// An enum containing the rank statuses a beatmapset can have.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapset-rank-status"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public enum RankedStatus
{
  /// <summary>
  /// The beatmap is in the graveyard.
  /// </summary>
  [JsonApiName("graveyard")]
  Graveyard = -2,

  /// <summary>
  /// The beatmap is a work in progress.
  /// </summary>
  [JsonApiName("wip")]
  WIP = -1,

  /// <summary>
  /// The beatmap is pending a rank status evaluation.
  /// </summary>
  [JsonApiName("pending")]
  Pending = 0,

  /// <summary>
  /// The beatmap is ranked.
  /// </summary>
  [JsonApiName("ranked")]
  Ranked = 1,

  /// <summary>
  /// The beatmap is approved.
  /// </summary>
  [JsonApiName("approved")]
  Approved = 2,

  /// <summary>
  /// The beatmap is qualified.
  /// </summary>
  [JsonApiName("qualified")]
  Qualified = 3,

  /// <summary>
  /// The beatmap is loved.
  /// </summary>
  [JsonApiName("loved")]
  Loved = 4
}

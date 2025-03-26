using osu.NET.Helpers;
using osu.NET.Models.Events;

namespace osu.NET.Enums;

/// <summary>
/// Represents the approval state of a <see cref="BeatmapsetApproveEvent"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public enum BeatmapsetEventApproval
{
  /// <summary>
  /// The beatmapset was ranked.
  /// </summary>
  [JsonApiName("ranked")]
  Ranked,

  /// <summary>
  /// The beatmapset was approved.
  /// </summary>
  [JsonApiName("approved")]
  Approved,

  /// <summary>
  /// The beatmapset was qualified.
  /// </summary>
  [JsonApiName("qualified")]
  Qualified,

  /// <summary>
  /// The beatmapset was loved.
  /// </summary>
  [JsonApiName("loved")]
  Loved
}

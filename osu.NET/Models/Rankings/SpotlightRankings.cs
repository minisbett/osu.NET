using Newtonsoft.Json;
using osu.NET.Models.Beatmaps;
using osu.NET.Models.Users;

namespace osu.NET.Models.Rankings;

/// <summary>
/// Represents the top 40 ranking of a beatmap spotlight.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/RankingController.php"/>
/// </summary>
public class SpotlightRankings
{
  /// <summary>
  /// The beatmapsets included in the spotlight.
  /// </summary>
  [JsonProperty("beatmapsets")]
  public BeatmapSet[] BeatmapSets { get; private set; } = default!;

  /// <summary>
  /// The top 40 users, in order.
  /// </summary>
  [JsonProperty("ranking")]
  public UserStatistics[] Users { get; private set; } = default!;

  /// <summary>
  /// The spotlight this object represents the ranking of.
  /// </summary>
  [JsonProperty("spotlight")]
  public Spotlight Spotlight { get; private set; } = default!;
}
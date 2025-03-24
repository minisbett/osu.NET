using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents the osu!mania key variant-specific statistics of a user.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-statistics-json.ts"/>
/// </summary>
public class StatisticsVariant
{
  /// <summary>
  /// The ruleset this variant is for. Currently, this is always osu!mania.
  /// </summary>
  [JsonProperty("mode")]
  public Ruleset Ruleset { get; private set; }

  /// <summary>
  /// The variant type.
  /// </summary>
  [JsonProperty("variant")]
  public VariantType Variant { get; private set; }

  /// <summary>
  /// The country rank in this variant. This will be null if the user has no rank.
  /// </summary>
  [JsonProperty("country_rank")]
  public int? CountryRank { get; private set; }

  /// <summary>
  /// The global rank in this variant. This will be null if the user has no rank.
  /// </summary>
  [JsonProperty("global_rank")]
  public int? GlobalRank { get; private set; }

  /// <summary>
  /// The PP in this variant.
  /// </summary>
  [JsonProperty("pp")]
  public double PP { get; private set; }
}

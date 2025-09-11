﻿using Newtonsoft.Json;
using osu.NET.Models.Users;

namespace osu.NET.Models.Rankings;

/// <summary>
/// Represents an entry in the country rankings.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Models/CountryStatistics.php"/>
/// </summary>
public class CountryStatistics
{
  /// <summary>
  /// The two-letter country code.
  /// </summary>
  [JsonProperty("code")]
  public string CountryCode { get; private set; } = default!;

  /// <summary>
  /// The amount of active users in the country.
  /// </summary>
  [JsonProperty("active_users")]
  public int ActiveUsers { get; private set; }

  /// <summary>
  /// The total ranked score of all users in the country.
  /// </summary>
  [JsonProperty("ranked_score")]
  public long RankedScore { get; private set; }

  /// <summary>
  /// The weighted PP of the country.
  /// </summary>
  [JsonProperty("performance")]
  public int PP { get; private set; }

  /// <summary>
  /// The country.
  /// </summary>
  [JsonProperty("country")]
  public Country Country { get; private set; } = default!;
}

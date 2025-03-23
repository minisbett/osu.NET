using osu.NET.Helpers;

namespace osu.NET.Enums;

/// <summary>
/// Represents the name of an update stream (stable40, beta40, cuttingedge, lazer, web).
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: Not documented, refer to API response
/// </summary>
public enum UpdateStreamName
{
  /// <summary>
  /// Represents the stable update stream of the osu!stable client.
  /// </summary>
  [QueryApiName("stable40")]
  [JsonApiName("stable40")]
  Stable40,

  /// <summary>
  /// Represents the beta update stream of the osu!stable client.
  /// </summary>
  [QueryApiName("beta40")]
  [JsonApiName("beta40")]
  Beta40,

  /// <summary>
  /// Represents the cutting edge update stream of the osu!stable client.
  /// </summary>
  [QueryApiName("cuttingedge")]
  [JsonApiName("cuttingedge")]
  CuttingEdge,

  /// <summary>
  /// Represents the update stream of the osu!lazer client.
  /// </summary>
  [QueryApiName("lazer")]
  [JsonApiName("lazer")]
  Lazer,

  /// <summary>
  /// Represents the update stream of osu!web.
  /// </summary>
  [QueryApiName("web")]
  [JsonApiName("web")]
  Web
}

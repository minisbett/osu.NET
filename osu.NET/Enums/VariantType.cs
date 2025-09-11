﻿using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Represents the type of a user statistics variant (eg. 4-key and 7-key for osu!mania).
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-statistics-json.ts"/>
/// </summary>
public enum VariantType
{
  /// <summary>
  /// The 4-key variant.
  /// </summary>
  [JsonApiName("4k")]
  Key4,

  /// <summary>
  /// The 7-key variant.
  /// </summary>
  [JsonApiName("7k")]
  Key7
}

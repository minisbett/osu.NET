using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Represents the playstyle of a user. A user can have multiple playstyles.
/// <br/><br/>
/// API docs: Not documented, refer to source<br/>
/// Source: Not documented, refer to API response and <a href="https://osu.ppy.sh/home/account/edit"/>
/// </summary>
public enum Playstyle
{
  /// <summary>
  /// The user plays with a mouse.
  /// </summary>
  [JsonApiName("mouse")]
  Mouse,

  /// <summary>
  /// The user plays with a keyboard.
  /// </summary>
  [JsonApiName("keyboard")]
  Keyboard,

  /// <summary>
  /// The user plays with a graphics tablet.
  /// </summary>
  [JsonApiName("tablet")]
  Tablet,

  /// <summary>
  /// The user plays with a touch screen.
  /// </summary>
  [JsonApiName("touch")]
  Touch
}

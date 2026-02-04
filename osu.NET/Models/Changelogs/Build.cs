using Newtonsoft.Json;

namespace osu.NET.Models.Changelogs;

/// <summary>
/// Represents a build of osu!-related software.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#build"/><br/>
/// Sources: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/changelog-build.ts"/>
/// </summary>
public class Build
{
  /// <summary>
  /// The datetime at which this build was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; init; }

  /// <summary>
  /// The display string for the version of this build (e.g. "20231219.2").<br/>
  /// This display version excludes any non-numeric and non-'.' characters from <see cref="Version"/>.
  /// </summary>
  [JsonProperty("display_version")]
  public string DisplayVersion { get; init; } = default!;

  /// <summary>
  /// The ID of this build.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; init; }

  /// <summary>
  /// The amount of currently online users using this build.
  /// </summary>
  [JsonProperty("users")]
  public int Users { get; init; }

  /// <summary>
  /// The version of this build (e.g. "20231219.2").
  /// </summary>
  [JsonProperty("version")]
  public string Version { get; init; } = default!;

  /// <summary>
  /// The YouTube video ID of the video that was uploaded for showcasing the updates of this build. This will be null if no video was uploaded.
  /// </summary>
  [JsonProperty("youtube_id")]
  public string? YouTubeID { get; init; } = default!;

  /// <summary>
  /// The changes made in this build. This will be null if this <see cref="Build"/> object is accessed via <see cref="UpdateStream.LatestBuild"/>.
  /// </summary>
  [JsonProperty("changelog_entries")]
  public ChangelogEntry[] Changelog { get; init; } = default!;

  /// <summary>
  /// The update stream this build belongs to.
  /// </summary>
  [JsonProperty("update_stream")]
  public UpdateStream UpdateStream { get; init; } = default!;

  /// <summary>
  /// The next and previous build version. This will be null if this build was requested alongside multiple others.
  /// </summary>
  [JsonProperty("versions")]
  public Versions Versions { get; init; } = default!;
}

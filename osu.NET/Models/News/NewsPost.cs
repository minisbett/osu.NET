using Newtonsoft.Json;

namespace osu.NET.Models.News;

/// <summary>
/// Represents a news post on the osu! website.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#newspost"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/news-post-json.ts"/>
/// </summary>
public class NewsPost
{
  /// <summary>
  /// The author(s) of this news post.
  /// </summary>
  [JsonProperty("author")]
  public string Author { get; init; } = default!;

  /// <summary>
  /// The URL to edit this news post on GitHub.
  /// </summary>
  [JsonProperty("edit_url")]
  public string EditUrl { get; init; } = default!;

  /// <summary>
  /// The URL to the first image in this post (thumbnail). This will be null if the post has no images.
  /// </summary>
  [JsonProperty("first_image")]
  public string? FirstImage { get; init; }

  /// <summary>
  /// The ID of this news post.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; init; }

  /// <summary>
  /// The datetime at which this news post was published.
  /// </summary>
  [JsonProperty("published_at")]
  public DateTimeOffset PublishedAt { get; init; }

  /// <summary>
  /// The slug of this news post. (eg. <c>2021-04-27-results-a-labour-of-love</c>)
  /// </summary>
  [JsonProperty("slug")]
  public string Slug { get; init; } = default!;

  /// <summary>
  /// The title of this news post.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; init; } = default!;

  /// <summary>
  /// The datetime at which this post was last updated.
  /// </summary>
  [JsonProperty("updated_at")]
  public DateTimeOffset UpdatedAt { get; init; }

  /// <summary>
  /// The HTML content of this news post. This will be null if this news post was requested alongside others.
  /// </summary>
  [JsonProperty("content")]
  public string? Content { get; init; }

  /// <summary>
  /// The navigation metadata for this news post, which contains the chronologically previous and next news post.
  /// This will be null if this news post was accessed from a <see cref="NewsNavigation"/> object or requested alongside others.
  /// </summary>
  [JsonProperty("navigation")]
  public NewsNavigation? Navigation { get; init; }

  /// <summary>
  /// The preview of this news post, which is the first paragraph of content with HTML markup stripped.
  /// This will be null if this news post object was not requested alongside multiple others.
  /// </summary>
  [JsonProperty("preview")]
  public string? Preview { get; init; }
}

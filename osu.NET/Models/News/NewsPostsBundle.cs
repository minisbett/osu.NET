using Newtonsoft.Json;

namespace osu.NET.Models.News;

/// <summary>
/// Represents a bundle containing news posts, related data and the cursor string for pagination.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-news-listing"/> (response)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/NewsController.php"/>
/// </summary>
public class NewsPostsBundle
{
  // search.limit (clamped limit parameter) and search.sort (always "published_desc") have been omitted here as they are useless information.

  /// <summary>
  /// The news posts.
  /// </summary>
  [JsonProperty("news_posts")]
  public NewsPost[] Posts { get; private set; } = default!;

  /// <summary>
  /// The information for the sidebar displayed alongside the news posts on the website.
  /// </summary>
  [JsonProperty("news_sidebar")]
  public NewsSidebar Sidebar { get; private set; } = default!;

  /// <summary>
  /// The cursor string for fetching further news posts.
  /// </summary>
  [JsonProperty("cursor_string")]
  public string Cursor { get; private set; } = default!;
}
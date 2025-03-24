using Newtonsoft.Json;

namespace osu.NET.Models.News;

/// <summary>
/// Represents information about the news sidebar when retrieving a bundle of news posts (years and posts published in current year).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-news-listing"/> (response)<br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/NewsController.php"/>
/// </summary>
public class NewsSidebar
{
  /// <summary>
  /// The year of the publish time of the first post in the bundle. If no posts are present, this will be the current year.
  /// </summary>
  [JsonProperty("current_year")]
  public int CurrentYear { get; private set; }

  /// <summary>
  /// The news posts published in <see cref="CurrentYear"/>.
  /// If the date of the API request is before April, posts from November to December of the previous year will also be included.
  /// </summary>
  [JsonProperty("news_posts")]
  public NewsPost[] Posts { get; private set; } = default!;

  /// <summary>
  /// An array of all years with news posts.
  /// </summary>
  [JsonProperty("years")]
  public int[] Years { get; private set; } = default!;
}

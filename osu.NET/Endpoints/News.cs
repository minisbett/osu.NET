using osu.NET.Helpers;
using osu.NET.Models.News;
using System;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#news

  /// <summary>
  /// Returns a bundle of news posts and the cursor string for fetching further posts.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="NewsPost.Preview"/></item>
  /// <item>Does not include <see cref="NewsPost.Content"/></item>
  /// <item>Does not include <see cref="NewsPost.Navigation"/></item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-news-listing"/>
  /// </summary>
  /// <param name="limit">Optional. The amount of news posts to return.</param>
  /// <param name="year">Optional. The year to return news posts of.</param>
  /// <param name="cursor">Optional. The cursor string for fetching further TYPE.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The bundle with the 50 most recent events across osu!.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<NewsPostsBundle>> GetNewsPostsAsync(int? limit = null, int? year = null, string? cursor = null,
    CancellationToken? cancellationToken = null)
    => await GetAsync<NewsPostsBundle>("news", cancellationToken,
    [
      ("limit", limit),
      ("year", year),
      ("cursor_string", cursor)
    ]);

  /// <summary>
  /// Returns the news post with the specified slug.<br/>
  /// The slug is a unique identifier for the news post, which is a part of the URL of the news post (eg. <c>2021-04-27-results-a-labour-of-love</c>).
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.NewsPostNotFound"/></term>
  ///   <description>The news post could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="NewsPost.Content"/></item>
  /// <item>Includes <see cref="NewsPost.Navigation"/></item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-news-post"/>
  /// </summary>
  /// <param name="slug">The slug of the news post (eg. <c>2021-04-27-results-a-labour-of-love</c>).</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The news post with the specified slug.</returns>
  [CanReturnApiError(ApiErrorType.NewsPostNotFound)]
  public async Task<ApiResult<NewsPost>> GetNewsPostAsync(string slug, CancellationToken? cancellationToken = null)
    => (await GetAsync<NewsPost>($"news/{slug}", cancellationToken)).WithErrorFallback(ApiErrorType.NewsPostNotFound);

  /// <summary>
  /// Returns the news post with the specified ID.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.NewsPostNotFound"/></term>
  ///   <description>The news post could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-news-post"/>
  /// </summary>
  /// <param name="id">The ID of the news post.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The news post with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.NewsPostNotFound)]
  public async Task<ApiResult<NewsPost>> GetNewsPostAsync(int id, CancellationToken? cancellationToken = null)
    => (await GetAsync<NewsPost>($"news/{id}", cancellationToken, [("key", id)])).WithErrorFallback(ApiErrorType.NewsPostNotFound);
}

﻿using osu.NET.Internal;
using osu.NET.Models.Forums;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#forum

  // TODOENDPOINT: https://osu.ppy.sh/docs/index.html#get-topic-listing (pagination)
  // TODOENDPOINT: https://osu.ppy.sh/docs/index.html#get-topic-and-posts (pagination)

  /// <summary>
  /// Returns a listing of all top-level forums on the website, including sub-forums up to two levels deep.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item><see cref="Forum.SubForums"/> includes sub-forums up to two levels deep</item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-forum-listing"/>
  /// </summary>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The top-level forums on the website.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<Forum[]>> GetForumListingAsync(CancellationToken? cancellationToken = null)
    => await GetAsync<Forum[]>("forums", cancellationToken, jsonSelector: json => json["forums"]);

  /// <summary>
  /// Returns the forum with the specified ID, as well as pinned topics, recent topics and sub-forums up to two levels deep.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.ForumNotFound"/></term>
  ///   <description>The forum could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-forum-and-topics"/>
  /// </summary>
  /// <param name="forumId">The ID of the forum.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The forum with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.ForumNotFound)]
  public async Task<ApiResult<ForumBundle>> GetForumAsync(int forumId, CancellationToken? cancellationToken = null)
    => await GetAsync<ForumBundle>($"forums/{forumId}", cancellationToken);
}

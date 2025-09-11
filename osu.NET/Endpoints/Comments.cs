using osu.NET.Enums;
using osu.NET.Internal;
using osu.NET.Models.Comments;

namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#comments

  /// <summary>
  /// Returns a bundle of comments with the specified filter options. One request returns 50 comments.
  /// <br/><br/>
  /// API notes:
  /// <list type="bullet">
  /// <item>Includes <see cref="CommentsBundle.PinnedComments"/> if <paramref name="type"/> and <paramref name="commentableId"/> are specified.</item>
  /// </list>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-comments"/>
  /// </summary>
  /// <param name="after">Optional. The minmum ID for the comments to return.</param>
  /// <param name="type">Optional. The type of commentable to return comments of.</param>
  /// <param name="commentableId">Optional. The ID of the commentable to return the comments of.</param>
  /// <param name="parentId">Optional. The ID of the parent comment, returning its' replies.</param>
  /// <param name="sort">Optional. The sorting for the returned comments.</param>
  /// <param name="cursor">Optional. The cursor for fetching further comments.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>A bundle with comments.</returns>
  [CanReturnApiError()]
  public async Task<ApiResult<CommentsBundle>> GetCommentsAsync(int? after = null, CommentableType? type = null, int? commentableId = null,
    int? parentId = null, CommentSortType? sort = null, CommentsCursor? cursor = null, CancellationToken? cancellationToken = null)
    => await GetAsync<CommentsBundle>("comments", cancellationToken,
    [
      ("cursor[id]", cursor?.Id),
      ("cursor[created_at]", cursor?.CreatedAt),
      ("after", after),
      ("commentable_type", type),
      ("commentable_id", commentableId),
      ("parent_id", parentId),
      ("sort", sort)
    ]);

  /// <summary>
  /// Returns a comment bundle containing the comment with the specified ID and replies up to 2 levels deep.
  /// <br/><br/>
  /// Errors:<br/>
  /// <item>
  ///   <term><see cref="ApiErrorType.CommentNotFound"/></term>
  ///   <description>The comment could not be found</description>
  /// </item>
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-a-comment"/>
  /// </summary>
  /// <param name="commentId">The ID of the comment.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The comment bundle containing the comment with the specified ID.</returns>
  [CanReturnApiError(ApiErrorType.CommentNotFound)]
  public async Task<ApiResult<CommentsBundle>> GetCommentAsync(int commentId, CancellationToken? cancellationToken = null)
    => await GetAsync<CommentsBundle>($"comments/{commentId}", cancellationToken);
}
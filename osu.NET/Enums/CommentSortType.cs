using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Represents the sort types for comments.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#commentsort"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/models/comment.ts"/>
/// </summary>
public enum CommentSortType
{
  /// <summary>
  /// Sorts the comments by creation date, with the newest comments first.
  /// </summary>
  [QueryApiName("new")]
  New,

  /// <summary>
  /// Sorts the comments by creation date, with the oldest comments first.
  /// </summary>
  [QueryApiName("old")]
  Old,

  /// <summary>
  /// Sorts the comments by the number of upvotes, with the most upvoted comment first.
  /// </summary>
  [QueryApiName("top")]
  Top
}

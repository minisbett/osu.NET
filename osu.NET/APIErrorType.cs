﻿namespace osu.NET
{
  /// <summary>
  /// Represents the type of error returned by the osu! API (eg. beatmap not found, user not found, ...).
  /// </summary>
  public enum ApiErrorType
  {
    /// <summary>
    /// There is no error message.
    /// </summary>
    Null,

    /// <summary>
    /// The error message does not have a mapping and is thus of unknown type.
    /// </summary>
    Unknown,

    /// <summary>
    /// Indicates that the beatmap in the request could not be found.
    /// </summary>
    BeatmapNotFound,

    /// <summary>
    /// Indicates that the beatmapset in the request could not be found.
    /// </summary>
    BeatmapSetNotFound,

    /// <summary>
    /// Indicates that the beatmap pack in the request could not be found.
    /// </summary>
    BeatmapPackNotFound,

    /// <summary>
    /// Indicates that the user in the request could not be found.
    /// </summary>
    UserNotFound,

    /// <summary>
    /// Indicates that the user or the score(s) in the request could not be found.<br/>
    /// Some API endpoints do not return an error that allows to tell these apart.
    /// </summary>
    UserOrScoreNotFound,

    /// <summary>
    /// Indicates that the build in the request could not be found.
    /// </summary>
    BuildNotFound,

    /// <summary>
    /// Indicates that the comment in the request could not be found.
    /// </summary>
    CommentNotFound,

    /// <summary>
    /// Indicates that the news post in the request could not be found.
    /// </summary>
    NewsPostNotFound,

    /// <summary>
    /// Indicates that the wiki page (or locale) in the request could not be found.
    /// </summary>
    WikiPageNotFound,

    /// <summary>
    /// Indicates that one of the mods in the request is invalid for the ruleset in the context.
    /// </summary>
    InvalidMod,

    /// <summary>
    /// Indicates that the forum in the request could not be found.
    /// </summary>
    ForumNotFound,

    /// <summary>
    /// Indicates that the match in the request could not be found.
    /// </summary>
    MatchNotFound,

    /// <summary>
    /// Indicates that the score in the request could not be found.
    /// </summary>
    ScoreNotFound,

    /// <summary>
    /// Indicates that the spotlight in the request could not be found.
    /// </summary>
    SpotlightNotFound,

    /// <summary>
    /// Indicates that the ruleset is invalid for the spotlight in the request.
    /// </summary>
    InvalidRulesetForSpotlight
  }
}
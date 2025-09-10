namespace osu.NET;

/// <summary>
/// Represents an error returned by the osu! API.
/// </summary>
public class ApiError
{
  internal ApiError(ApiErrorType type, string? message)
  {
    Type = type;
    Message = message;
  }

  /// <summary>
  /// The type of error returned, determined from a lookup table on the error message provided by the osu! API.<br/>
  /// This is useful for error-handling API requests for different erroring scenarios.
  /// </summary>
  public ApiErrorType Type { get; internal set; }

  /// <summary>
  /// The error message provided by the osu! API. This can be null.
  /// </summary>
  public string? Message { get; }

  /// <summary>
  /// Returns an <see cref="ApiError"/> object based on the specified error message. The <see cref="Type"/> is determined from a lookup table on 
  /// the error message, or will be <see cref="ApiErrorType.Unknown"/> if the error message is not associated with an <see cref="ApiErrorType"/>.
  /// </summary>
  /// <param name="message">The error message provided by the osu! API.</param>
  /// <returns>The parsed <see cref="ApiError"/>.</returns>
  internal static ApiError FromMessage(string? message)
  {
    if (message is null)
      return new(ApiErrorType.Null, null);
    else if (_errorMessageMappings.TryGetValue(message, out ApiErrorType type))
      return new(type, message);

    return new(ApiErrorType.Unknown, message);
  }

  /// <inheritdoc/>
  public override string ToString()
  {
    return $"({Type}) {Message}";
  }

  /// <summary>
  /// Represents a mapping between error messages returned by the osu! API and their corresponding <see cref="ApiErrorType"/>.
  /// </summary>
  private static readonly Dictionary<string, ApiErrorType> _errorMessageMappings = new()
  {
    ["Specified beatmap difficulty couldn't be found."] = ApiErrorType.BeatmapNotFound,
    ["Specified beatmap couldn't be found."] = ApiErrorType.BeatmapSetNotFound,
    ["Specified BeatmapPack couldn't be found."] = ApiErrorType.BeatmapPackNotFound,
    ["Specified Build couldn't be found."] = ApiErrorType.BuildNotFound,
    ["Specified Comment couldn't be found."] = ApiErrorType.CommentNotFound,
    ["Specified Forum\\Forum couldn't be found."] = ApiErrorType.ForumNotFound,
    ["Specified LegacyMatch\\LegacyMatch couldn't be found."] = ApiErrorType.MatchNotFound,
    ["Specified Solo\\Score couldn't be found."] = ApiErrorType.ScoreNotFound,
    ["Specified Spotlight couldn't be found."] = ApiErrorType.SpotlightNotFound,
    ["ruleset osu isn't available for the specified spotlight"] = ApiErrorType.InvalidRulesetForSpotlight,
    ["ruleset taiko isn't available for the specified spotlight"] = ApiErrorType.InvalidRulesetForSpotlight,
    ["ruleset fruits isn't available for the specified spotlight"] = ApiErrorType.InvalidRulesetForSpotlight,
    ["ruleset mania isn't available for the specified spotlight"] = ApiErrorType.InvalidRulesetForSpotlight
  };
}
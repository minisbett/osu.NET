using System.Diagnostics.CodeAnalysis;

namespace osu.NET;

/// <summary>
/// Represents a result from an osu! API request.
/// </summary>
/// <typeparam name="T">The return type of the endpoint.</typeparam>
public class ApiResult<T> where T : class
{
  /// <summary>
  /// Creates a successful <see cref="ApiResult{T}"/> with the specified returned value.
  /// </summary>
  /// <param name="value">The value returned by the osu! API.</param>
  internal ApiResult(T? value)
  {
    Value = value;
  }

  /// <summary>
  /// Creates a successful <see cref="ApiResult{T}"/> with the specified error.
  /// </summary>
  /// <param name="error">The error returned by the osu! API.</param>
  internal ApiResult(ApiError error)
  {
    ArgumentNullException.ThrowIfNull(error, nameof(error));

    Error = error;
  }

  /// <summary>
  /// The value returned by the osu! API. If the result indicates an error, accessing this value will throw an exception.
  /// </summary>
  public T? Value
  {
    get
    {
      if (IsFailure)
        throw new InvalidOperationException($"Cannot access the value of a failed {nameof(ApiResult<T>)}.");

      return field;
    }
  }

  /// <summary>
  /// The error returned by the osu! API. This will be null if the request was successful.
  /// </summary>
  public ApiError? Error { get; }

  /// <summary>
  /// Bool whether the request was successful.
  /// </summary>
  [MemberNotNullWhen(false, nameof(Error))]
  public bool IsSuccess => Error is null;

  /// <summary>
  /// Bool whether the request failed.
  /// </summary>
  [MemberNotNullWhen(true, nameof(Error))]
  public bool IsFailure => !IsSuccess;

  /// <summary>
  /// Sets the <see cref="ApiErrorType"/> of the <see cref="Error"/> to the specified error type if the API result indicates <see cref="ApiErrorType.Null"/>.
  /// </summary>
  /// <param name="errorType">The error to replace <see cref="ApiErrorType.Null"/> with.</param>
  internal ApiResult<T> WithErrorFallback(ApiErrorType errorType)
  {
    if (Error?.Type is ApiErrorType.Null)
      Error.Type = errorType;

    return this;
  }

  /// <summary>
  /// Matches the API result to execute the corresponding success or error handler.
  /// </summary>
  /// <param name="success">Executed if the API request was successful, receiving the value.</param>
  /// <param name="error">Executed if the API request failed, receiving the error.</param>
  public void Match(Action<T?> success, Action<ApiError> error)
  {
    if (IsSuccess)
      success(Value);
    else
      error(Error);
  }

  /// <summary>
  /// Matches the API result to execute the corresponding success or error handler.
  /// </summary>
  /// <param name="success">Executed if the API request was successful, receiving the value.</param>
  /// <param name="error">Executed if the API request failed, receiving the error.</param>
  public void Match(Action<T?> success, Func<ApiError, Action> error)
  {
    if (IsSuccess)
      success(Value);
    else
      error(Error)();
  }

  /// <summary>
  /// Matches the API result to execute the corresponding success or error handler, returning a value of type <typeparamref name="TReturn"/>.
  /// </summary>
  /// <param name="success">Executed if the API request was successful, receiving the value.</param>
  /// <param name="error">Executed if the API request failed, receiving the error.</param>
  public TReturn Match<TReturn>(Func<T?, TReturn> success, Func<ApiError, TReturn> error)
  {
    return IsSuccess ? success(Value) : error(Error);
  }

  /// <summary>
  /// Matches the API result to execute the corresponding success or error handler, returning a value of type <typeparamref name="TReturn"/>.
  /// </summary>
  /// <param name="success">Executed if the API request was successful, receiving the value.</param>
  /// <param name="error">Executed if the API request failed, receiving the error.</param>
  public TReturn Match<TReturn>(Func<T?, TReturn> success, Func<ApiError, Func<TReturn>> error)
  {
    return IsSuccess ? success(Value) : error(Error)();
  }

  /// <summary>
  /// Implicitly converts an <see cref="ApiError"/> into a failed <see cref="ApiResult{T}"/>.
  /// </summary>
  /// <param name="error">The error.</param>
  public static implicit operator ApiResult<T>(ApiError error) => new(error);

  /// <summary>
  /// Implicitly converts a nullable <typeparamref name="T"/> into a successful <see cref="ApiResult{T}"/>.
  /// </summary>
  /// <param name="value">The value.</param>
  public static implicit operator ApiResult<T>(T? value) => new(value);

  /// <inheritdoc/>
  public override string ToString()
  {
    return IsSuccess ? $"Success: {Value}" : $"Failure: {Error}";
  }
}
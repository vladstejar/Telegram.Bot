using JetBrains.Annotations;

namespace Telegram.Bot.Types;

/// <summary>
/// Represents bot API response
/// </summary>
/// <typeparam name="TResult">Expected type of operation result</typeparam>
/// <param name="ok">Indicating whether the request was successful</param>
/// <param name="result">Result object</param>
/// <param name="errorCode">Error code</param>
/// <param name="description">Error message</param>
/// <param name="parameters">Information about why a request was unsuccessful</param>
[PublicAPI]
[method: JsonConstructor]
public class ApiResponse<TResult>(
    bool ok,
    TResult result,
    int errorCode,
    string description,
    ResponseParameters? parameters = default)
{
    /// <summary>
    /// Gets a value indicating whether the request was successful.
    /// </summary>
    public bool Ok { get; } = ok;

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string? Description { get; } = description;

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public int? ErrorCode { get; } = errorCode;

    /// <summary>
    /// Contains information about why a request was unsuccessful.
    /// </summary>
    public ResponseParameters? Parameters { get; } = parameters;

    /// <summary>
    /// Gets the result object.
    /// </summary>
    public TResult? Result { get; } = result;
}

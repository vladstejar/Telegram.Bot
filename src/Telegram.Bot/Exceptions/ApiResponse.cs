using JetBrains.Annotations;

namespace Telegram.Bot.Exceptions;

/// <summary>
/// Represents failed API response
/// </summary>
/// <remarks>
/// Initializes an instance of <see cref="ApiResponse"/>
/// </remarks>
/// <param name="errorCode">Error code</param>
/// <param name="description">Error message</param>
/// <param name="parameters">Information about why a request was unsuccessful</param>
[PublicAPI]
public class ApiResponse(
    int errorCode,
    string description,
    ResponseParameters? parameters)
{
    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Description { get; private set; } = description;

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public int ErrorCode { get; private set; } = errorCode;

    /// <summary>
    /// Contains information about why a request was unsuccessful.
    /// </summary>
    public ResponseParameters? Parameters { get; private set; } = parameters;
}

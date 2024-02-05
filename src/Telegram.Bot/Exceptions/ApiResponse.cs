namespace Telegram.Bot.Exceptions;

/// <summary>
/// Represents failed API response
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ApiResponse
{
    /// <summary>
    /// Gets the error message.
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Description { get; private set; }

    /// <summary>
    /// Gets the error code.
    /// </summary>
    [DataMember(IsRequired = true)]
    public int ErrorCode { get; private set; }

    /// <summary>
    /// Contains information about why a request was unsuccessful.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ResponseParameters? Parameters { get; private set; }

    /// <summary>
    /// Initializes an instance of <see cref="ApiResponse"/>
    /// </summary>
    /// <param name="errorCode">Error code</param>
    /// <param name="description">Error message</param>
    /// <param name="parameters">Information about why a request was unsuccessful</param>
    public ApiResponse(
        int errorCode,
        string description,
        ResponseParameters? parameters)
    {
        ErrorCode = errorCode;
        Description = description;
        Parameters = parameters;
    }
}

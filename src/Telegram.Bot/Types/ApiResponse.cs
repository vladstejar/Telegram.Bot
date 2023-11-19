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
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
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
    [JsonProperty(Required = Required.Always)]
    public bool Ok { get; } = ok;

    /// <summary>
    /// Gets the error message.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Description { get; } = description;

    /// <summary>
    /// Gets the error code.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? ErrorCode { get; } = errorCode;

    /// <summary>
    /// Contains information about why a request was unsuccessful.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ResponseParameters? Parameters { get; } = parameters;

    /// <summary>
    /// Gets the result object.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public TResult? Result { get; } = result;
}

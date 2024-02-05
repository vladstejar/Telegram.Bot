namespace Telegram.Bot.Types;

/// <summary>
/// Contains information about why a request was unsuccessful.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ResponseParameters
{
    /// <summary>
    /// The group has been migrated to a supergroup with the specified identifier.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public long? MigrateToChatId { get; set; }

    /// <summary>
    /// In case of exceeding flood control, the number of seconds left to wait before the request can be repeated.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? RetryAfter { get; set; }
}

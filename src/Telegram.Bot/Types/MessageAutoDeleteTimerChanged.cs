namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about a change in auto-delete timer settings.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class MessageAutoDeleteTimerChanged
{
    /// <summary>
    /// New auto-delete time for messages in the chat
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int MessageAutoDeleteTime { get; set; }
}

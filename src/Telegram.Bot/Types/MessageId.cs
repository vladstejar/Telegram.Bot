namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a messageId.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class MessageId
{
    /// <summary>
    /// Message identifier in the chat specified in <see cref="Requests.CopyMessageRequest.FromChatId"/>
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always, PropertyName = "message_id")]
    #endif
    public int Id { get; set; }
}

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a messageId.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class MessageId
{
    /// <summary>
    /// Message identifier in the chat specified in <see cref="Requests.CopyMessageRequest.FromChatId"/>
    /// </summary>
    [DataMember(Name = "message_id", IsRequired = true)]
    public int Id { get; set; }
}

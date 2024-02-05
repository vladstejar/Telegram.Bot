namespace Telegram.Bot.Types;

/// <summary>
/// Contains information about an inline message sent by a
/// <a href="https://core.telegram.org/bots/webapps">Web App</a> on behalf of a user.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SentWebAppMessage
{
    /// <summary>
    /// Optional. Identifier of the sent inline message. Available only if there is an inline keyboard attached
    /// to the message.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? InlineMessageId { get; set; }
}

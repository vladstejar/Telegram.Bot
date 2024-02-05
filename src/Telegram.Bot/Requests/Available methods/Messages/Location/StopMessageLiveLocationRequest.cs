using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to stop updating a live location message before
/// <see cref="Types.Location.LivePeriod"/> expires. On success the sent
/// <see cref="Message"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class StopMessageLiveLocationRequest : RequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Identifier of the sent message
    /// </summary>
    [DataMember(IsRequired = true)]
    public int MessageId { get; }

    /// <inheritdoc cref="Abstractions.Documentation.InlineReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with chatId and messageId
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="messageId">Identifier of the sent message</param>
    public StopMessageLiveLocationRequest(ChatId chatId, int messageId)
        : base("stopMessageLiveLocation")
    {
        ChatId = chatId;
        MessageId = messageId;
    }
}

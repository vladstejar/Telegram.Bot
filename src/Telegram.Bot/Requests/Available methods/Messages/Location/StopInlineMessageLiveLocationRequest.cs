using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to stop updating a live location message before <see cref="Types.Location.LivePeriod"/> expires.
/// On success <see langword="true"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class StopInlineMessageLiveLocationRequest : RequestBase<bool>
{
    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    [DataMember(IsRequired = true)]
    public string InlineMessageId { get; }

    /// <inheritdoc cref="Abstractions.Documentation.InlineReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with inlineMessageId
    /// </summary>
    /// <param name="inlineMessageId">Identifier of the inline message</param>
    public StopInlineMessageLiveLocationRequest(string inlineMessageId)
        : base("stopMessageLiveLocation")
    {
        InlineMessageId = inlineMessageId;
    }
}

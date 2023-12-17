using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to stop updating a live location message before <see cref="Types.Location.LivePeriod"/> expires.
/// On success <see langword="true"/> is returned.
/// </summary>
/// <param name="inlineMessageId">Identifier of the inline message</param>
public class StopInlineMessageLiveLocationRequest(string inlineMessageId)
    : RequestBase<bool>("stopMessageLiveLocation")
{
    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    public string InlineMessageId { get; } = inlineMessageId;

    /// <inheritdoc cref="Abstractions.Documentation.InlineReplyMarkup"/>
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

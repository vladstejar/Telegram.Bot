using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit only the reply markup of messages. On success <see langword="true"/> is returned.
/// </summary>
/// <param name="inlineMessageId">Identifier of the inline message</param>
public class EditInlineMessageReplyMarkupRequest(string inlineMessageId) : RequestBase<bool>("editMessageReplyMarkup")
{
    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    public string InlineMessageId { get; } = inlineMessageId;

    /// <inheritdoc cref="Documentation.InlineReplyMarkup"/>

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

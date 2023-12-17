using System.Collections.Generic;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit text and game messages. On success <see langword="true"/> is returned.
/// </summary>
/// <param name="inlineMessageId">Identifier of the inline message</param>
/// <param name="text">New text of the message, 1-4096 characters after entities parsing</param>
public class EditInlineMessageTextRequest(string inlineMessageId, string text) : RequestBase<bool>("editMessageText")
{
    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    public string InlineMessageId { get; } = inlineMessageId;

    /// <summary>
    /// New text of the message, 1-4096 characters after entities parsing
    /// </summary>
    public string Text { get; } = text;

    /// <inheritdoc cref="Documentation.ParseMode"/>

    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.Entities"/>

    public IEnumerable<MessageEntity>? Entities { get; set; }

    /// <summary>
    /// Disables link previews for links in this message
    /// </summary>
    public bool? DisableWebPagePreview { get; set; }

    /// <inheritdoc cref="Documentation.ReplyMarkup"/>

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

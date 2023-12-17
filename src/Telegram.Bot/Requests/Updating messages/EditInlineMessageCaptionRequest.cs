using System.Collections.Generic;
using JetBrains.Annotations;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit captions of messages. On success <see langword="true"/> is returned.
/// </summary>
/// <param name="inlineMessageId">Identifier of the inline message</param>
[PublicAPI]
public class EditInlineMessageCaptionRequest(string inlineMessageId) : RequestBase<bool>("editMessageCaption")
{
    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    public string InlineMessageId { get; } = inlineMessageId;

    /// <summary>
    /// New caption of the message, 0-1024 characters after entities parsing
    /// </summary>
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode"/>
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities"/>
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.ReplyMarkup"/>
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

using System.Collections.Generic;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit text and game messages. On success the edited <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="messageId">Identifier of the message to edit</param>
/// <param name="text">New text of the message, 1-4096 characters after entities parsing</param>
public class EditMessageTextRequest(ChatId chatId, int messageId, string text)
    : RequestBase<Message>("editMessageText"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Identifier of the message to edit
    /// </summary>
    public int MessageId { get; } = messageId;

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

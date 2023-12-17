using System.Collections.Generic;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit captions of messages. On success the edited <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="messageId">Identifier of the message to edit</param>
public class EditMessageCaptionRequest(ChatId chatId, int messageId)
    : RequestBase<Message>("editMessageCaption"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Identifier of the message to edit
    /// </summary>
    public int MessageId { get; } = messageId;

    /// <summary>
    /// New caption of the message, 0-1024 characters after entities parsing
    /// </summary>
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode"/>

    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities"/>

    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.InlineReplyMarkup"/>

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

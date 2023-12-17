using System.Collections.Generic;
using JetBrains.Annotations;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to copy messages of any kind. Service messages and invoice messages can't be copied.
/// The method is analogous to the method <see cref="ForwardMessageRequest"/>, but the copied message
/// doesn't have a link to the original message. Returns the <see cref="Types.MessageId"/> of the
/// sent <see cref="Message"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="fromChatId">
/// Unique identifier for the chat where the original message was sent
/// (or channel username in the format <c>@channelusername</c>)
/// </param>
/// <param name="messageId">
/// Message identifier in the chat specified in <see cref="FromChatId"/>
/// </param>
[PublicAPI]
public class CopyMessageRequest(ChatId chatId, ChatId fromChatId, int messageId)
    : RequestBase<MessageId>("copyMessage"),
      IChatTargetable
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </summary>
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Unique identifier for the chat where the original message was sent
    /// (or channel username in the format <c>@channelusername</c>)
    /// </summary>
    public ChatId FromChatId { get; } = fromChatId;

    /// <summary>
    /// Message identifier in the chat specified in <see cref="FromChatId"/>
    /// </summary>
    public int MessageId { get; } = messageId;

    /// <summary>
    /// New caption for media, 0-1024 characters after entities parsing.
    /// If not specified, the original caption is kept
    /// </summary>
    public string? Caption { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ParseMode"/>
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.CaptionEntities"/>
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    public IReplyMarkup? ReplyMarkup { get; set; }
}

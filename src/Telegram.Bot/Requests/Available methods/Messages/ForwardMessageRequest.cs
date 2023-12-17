using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to forward messages of any kind. Service messages can't be forwarded.
/// On success, the sent <see cref="Message"/> is returned.
/// </summary>
public class ForwardMessageRequest(ChatId chatId, ChatId fromChatId, int messageId)
    : RequestBase<Message>("forwardMessage"),
      IChatTargetable
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </summary>
    public ChatId ChatId { get; } = chatId;

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
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    public bool? ProtectContent { get; set; }
}

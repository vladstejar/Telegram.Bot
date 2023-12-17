using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to stop a poll which was sent by the bot. On success, the stopped <see cref="Poll"/>
/// with the final results is returned.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target channel (in the format
/// <c>@channelusername</c>)
/// </param>
/// <param name="messageId">Identifier of the original message with the poll</param>
public class StopPollRequest(ChatId chatId, int messageId) : RequestBase<Poll>("stopPoll"), IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Identifier of the original message with the poll
    /// </summary>
    public int MessageId { get; } = messageId;

    /// <inheritdoc cref="Documentation.InlineReplyMarkup"/>

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

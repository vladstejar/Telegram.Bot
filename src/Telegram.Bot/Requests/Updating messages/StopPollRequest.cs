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
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class StopPollRequest(ChatId chatId, int messageId) : RequestBase<Poll>("stopPoll"), IChatTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Identifier of the original message with the poll
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int MessageId { get; } = messageId;

    /// <inheritdoc cref="Documentation.InlineReplyMarkup"/>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get the number of members in a chat. Returns <c>int</c> on success.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target supergroup or channel
/// (in the format <c>@channelusername</c>)
/// </param>
public class GetChatMemberCountRequest(ChatId chatId) : RequestBase<int>("getChatMemberCount"), IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;
}

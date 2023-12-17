using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get information about a member of a chat. Returns a <see cref="ChatMember"/>
/// object on success.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target supergroup or channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="userId">Unique identifier of the target user</param>
public class GetChatMemberRequest(ChatId chatId, long userId)
    : RequestBase<ChatMember>("getChatMember"),
      IChatTargetable,
      IUserTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <inheritdoc />
    public long UserId { get; } = userId;
}

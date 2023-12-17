using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to decline a chat join request. The bot must be an administrator in the chat for this to
/// work and must have the <see cref="ChatPermissions.CanInviteUsers"/> administrator right.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="userId">Unique identifier of the target user</param>
public class DeclineChatJoinRequest(ChatId chatId, long userId)
    : RequestBase<bool>("declineChatJoinRequest"),
      IChatTargetable,
      IUserTargetable
{
    /// <inheritdoc/>

    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier of the target user
    /// </summary>
    public long UserId { get; } = userId;
}

using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to decline a chat join request. The bot must be an administrator in the chat for this to
/// work and must have the <see cref="ChatPermissions.CanInviteUsers"/> administrator right.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class DeclineChatJoinRequest : RequestBase<bool>, IChatTargetable, IUserTargetable
{
    /// <inheritdoc/>
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Unique identifier of the target user
    /// </summary>
    [DataMember(IsRequired = true)]
    public long UserId { get; }

    /// <summary>
    /// Initializes a new request with chatId and userId
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="userId">Unique identifier of the target user</param>
    public DeclineChatJoinRequest(ChatId chatId, long userId)
        : base("declineChatJoinRequest")
    {
        ChatId = chatId;
        UserId = userId;
    }
}

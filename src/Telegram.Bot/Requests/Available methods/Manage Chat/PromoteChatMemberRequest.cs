using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to promote or demote a user in a supergroup or a channel. The bot must be
/// an administrator in the chat for this to work and must have the appropriate admin rights.
/// Pass <see langword="false"/> for all boolean parameters to demote a user. Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="userId">Unique identifier of the target user</param>
public class PromoteChatMemberRequest(ChatId chatId, long userId)
    : RequestBase<bool>("promoteChatMember"),
      IChatTargetable,
      IUserTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <inheritdoc />
    public long UserId { get; } = userId;

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator's presence in the chat is hidden
    /// </summary>
    public bool? IsAnonymous { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can access the chat event log, chat statistics, message
    /// statistics in channels, see channel members, see anonymous administrators in supergroups
    /// and ignore slow mode. Implied by any other administrator privilege
    /// </summary>
    public bool? CanManageChat { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can create channel posts, channels only
    /// </summary>
    public bool? CanPostMessages { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can edit messages of other users and can pin messages,
    /// channels only
    /// </summary>
    public bool? CanEditMessages { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can delete messages of other users
    /// </summary>
    public bool? CanDeleteMessages { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the administrator can post stories in the channel; channels only
    /// </summary>
    public bool? CanPostStories { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the administrator can edit stories posted by other users; channels only
    /// </summary>
    public bool? CanEditStories { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the administrator can delete stories posted by other users; channels only
    /// </summary>
    public bool? CanDeleteStories { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can manage video chats
    /// </summary>
    public bool? CanManageVideoChat { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can restrict, ban or unban chat members
    /// </summary>
    public bool? CanRestrictMembers { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can add new administrators with a subset of their own
    /// privileges or demote administrators that he has promoted, directly or indirectly
    /// (promoted by administrators that were appointed by him)
    /// </summary>
    public bool? CanPromoteMembers { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can change chat title, photo and other settings
    /// </summary>
    public bool? CanChangeInfo { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can invite new users to the chat
    /// </summary>
    public bool? CanInviteUsers { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can pin messages, supergroups only
    /// </summary>
    public bool? CanPinMessages { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the user is allowed to create, rename, close, and reopen forum topics, supergroups only
    /// </summary>
    public bool? CanManageTopics { get; set; }
}

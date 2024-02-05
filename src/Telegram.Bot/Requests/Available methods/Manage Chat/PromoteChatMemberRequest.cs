using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to promote or demote a user in a supergroup or a channel. The bot must be
/// an administrator in the chat for this to work and must have the appropriate admin rights.
/// Pass <see langword="false"/> for all boolean parameters to demote a user. Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class PromoteChatMemberRequest : RequestBase<bool>, IChatTargetable, IUserTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public long UserId { get; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator's presence in the chat is hidden
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? IsAnonymous { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can access the chat event log, chat statistics, message
    /// statistics in channels, see channel members, see anonymous administrators in supergroups
    /// and ignore slow mode. Implied by any other administrator privilege
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanManageChat { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can create channel posts, channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanPostMessages { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can edit messages of other users and can pin messages,
    /// channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanEditMessages { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can delete messages of other users
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanDeleteMessages { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the administrator can post stories in the channel; channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanPostStories { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the administrator can edit stories posted by other users; channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanEditStories { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the administrator can delete stories posted by other users; channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanDeleteStories { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can manage video chats
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanManageVideoChat { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can restrict, ban or unban chat members
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanRestrictMembers { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can add new administrators with a subset of their own
    /// privileges or demote administrators that he has promoted, directly or indirectly
    /// (promoted by administrators that were appointed by him)
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanPromoteMembers { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can change chat title, photo and other settings
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanChangeInfo { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can invite new users to the chat
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanInviteUsers { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the administrator can pin messages, supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanPinMessages { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the user is allowed to create, rename, close, and reopen forum topics, supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanManageTopics { get; set; }

    /// <summary>
    /// Initializes a new request with chatId and userId
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="userId">Unique identifier of the target user</param>
    public PromoteChatMemberRequest(ChatId chatId, long userId)
        : base("promoteChatMember")
    {
        ChatId = chatId;
        UserId = userId;
    }
}

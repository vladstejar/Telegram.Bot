using Telegram.Bot.Converters;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit a non-primary invite link created by the bot. The bot must be an administrator
/// in the chat for this to work and must have the appropriate admin rights. Returns the edited invite
/// link as a <see cref="Types.ChatInviteLink"/> object.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="inviteLink">The invite link to edit</param>
public class EditChatInviteLinkRequest(ChatId chatId, string inviteLink)
    : RequestBase<ChatInviteLink>("editChatInviteLink"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// The invite link to edit
    /// </summary>
    public string InviteLink { get; } = inviteLink;

    /// <summary>
    /// Invite link name; 0-32 characters
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Point in time when the link will expire
    /// </summary>
    [JsonConverter(typeof(NullableUnixDateTimeConverter))]
    public DateTime? ExpireDate { get; set; }

    /// <summary>
    ///	Maximum number of users that can be members of the chat simultaneously after joining the
    /// chat via this invite link; 1-99999
    /// </summary>
    public int? MemberLimit { get; set; }

    /// <summary>
    /// Set to <see langword="true"/>, if users joining the chat via the link need to be approved by chat
    /// administrators. If <see langword="true"/>, <see cref="MemberLimit"/> can't be specified
    /// </summary>
    public bool? CreatesJoinRequest { get; set; }
}

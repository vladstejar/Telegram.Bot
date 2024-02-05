using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to revoke an invite link created by the bot. If the primary link is revoked, a new
/// link is automatically generated. The bot must be an administrator in the chat for this to work and
/// must have the appropriate admin rights. Returns the revoked invite link as
/// <see cref="ChatInviteLink"/> object.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class RevokeChatInviteLinkRequest : RequestBase<ChatInviteLink>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// The invite link to revoke
    /// </summary>
    [DataMember(IsRequired = true)]
    public string InviteLink { get; }

    /// <summary>
    /// Initializes a new request with chatId and inviteLink
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="inviteLink">The invite link to revoke</param>
    public RevokeChatInviteLinkRequest(ChatId chatId, string inviteLink)
        : base("revokeChatInviteLink")
    {
        ChatId = chatId;
        InviteLink = inviteLink;
    }
}

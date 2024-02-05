using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to generate a new primary invite link for a chat; any previously generated primary
/// link is revoked. The bot must be an administrator in the chat for this to work and must have the
/// appropriate admin rights. Returns the new invite link as <c>string</c> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ExportChatInviteLinkRequest : RequestBase<string>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Initializes a new request with chatId
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    public ExportChatInviteLinkRequest(ChatId chatId)
        : base("exportChatInviteLink")
    {
        ChatId = chatId;
    }
}

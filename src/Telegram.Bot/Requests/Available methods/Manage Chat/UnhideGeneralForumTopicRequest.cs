using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to uhhide the 'General' topic in a forum supergroup chat. The bot must be an administrator in the
/// chat for this to work and must have the <see cref="ChatAdministratorRights.CanManageTopics"/> administrator rights.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class UnhideGeneralForumTopicRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
    public UnhideGeneralForumTopicRequest(ChatId chatId)
        : base("unhideGeneralForumTopic") => ChatId = chatId;
}

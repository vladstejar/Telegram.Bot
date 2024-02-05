using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to edit the name of the 'General' topic in a forum supergroup chat. The bot must be an
/// administrator in the chat for this to work and must have <see cref="ChatAdministratorRights.CanManageTopics"/>
/// administrator rights. Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class EditGeneralForumTopicRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// New topic name, 1-128 characters
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Name { get; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
    /// <param name="name">New topic name, 1-128 characters</param>
    public EditGeneralForumTopicRequest(ChatId chatId, string name)
        : base("editGeneralForumTopic") => (ChatId, Name) = (chatId, name);
}

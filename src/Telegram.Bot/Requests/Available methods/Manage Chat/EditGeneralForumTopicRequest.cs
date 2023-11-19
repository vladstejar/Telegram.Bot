using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to edit the name of the 'General' topic in a forum supergroup chat. The bot must be an
/// administrator in the chat for this to work and must have <see cref="ChatAdministratorRights.CanManageTopics"/>
/// administrator rights. Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
/// <param name="name">New topic name, 1-128 characters</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditGeneralForumTopicRequest(ChatId chatId, string name)
    : RequestBase<bool>("editGeneralForumTopic"),
      IChatTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// New topic name, 1-128 characters
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Name { get; } = name;
}

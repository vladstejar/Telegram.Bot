using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to reopen an open topic in a forum supergroup chat. The bot must be an administrator in the chat
/// for this to work and must have the <see cref="ChatAdministratorRights.CanManageTopics"/> administrator rights,
/// unless it is the creator of the topic. Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
/// <param name="messageThreadId">Unique identifier for the target message thread of the forum topic</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ReopenForumTopicRequest(ChatId chatId, int messageThreadId)
    : RequestBase<bool>("reopenForumTopic"),
      IChatTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread of the forum topic
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int MessageThreadId { get; } = messageThreadId;
}

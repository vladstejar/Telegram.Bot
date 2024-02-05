using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to clear the list of pinned messages in a forum topic. The bot must be an administrator in the chat
/// for this to work and must have the <see cref="ChatAdministratorRights.CanPinMessages"/> administrator rights,
/// unless it is the creator of the topic. Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class UnpinAllForumTopicMessagesRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Unique identifier for the target message thread of the forum topic
    /// </summary>
    [DataMember(IsRequired = true)]
    public int MessageThreadId { get; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
    /// <param name="messageThreadId">Unique identifier for the target message thread of the forum topic</param>
    public UnpinAllForumTopicMessagesRequest(ChatId chatId, int messageThreadId)
        : base("unpinAllForumTopicMessages")
    {
        ChatId = chatId;
        MessageThreadId = messageThreadId;
    }
}

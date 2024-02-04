using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to clear the list of pinned messages in a General forum topic. The bot must be an administrator in
/// the chat for this to work and must have the <see cref="ChatAdministratorRights.CanPinMessages"/> administrator right in the supergroup.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class UnpinAllGeneralForumTopicMessages : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public ChatId ChatId { get; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
    public UnpinAllGeneralForumTopicMessages(ChatId chatId)
        : base("unpinAllGeneralForumTopicMessages")
    {
        ChatId = chatId;
    }
}

using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get a list of administrators in a chat. On success, returns an Array of
/// <see cref="ChatMember"/> objects that contains information about all chat administrators
/// except other bots. If the chat is a group or a supergroup and no administrators were appointed,
/// only the creator will be returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class GetChatAdministratorsRequest : RequestBase<ChatMember[]>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Initializes a new request with chatId
    /// </summary>
    /// <param name="chatId">
    /// Unique identifier for the target chat or username of the target supergroup or channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    public GetChatAdministratorsRequest(ChatId chatId)
        : base("getChatAdministrators")
    {
        ChatId = chatId;
    }
}

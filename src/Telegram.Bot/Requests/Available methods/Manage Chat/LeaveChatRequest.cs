using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method for your bot to leave a group, supergroup or channel. Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class LeaveChatRequest : RequestBase<bool>, IChatTargetable
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
    public LeaveChatRequest(ChatId chatId)
        : base("leaveChat")
    {
        ChatId = chatId;
    }
}

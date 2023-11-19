using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to unban a previously banned channel chat in a supergroup or channel. The bot must be an
/// administrator for this to work and must have the appropriate administrator rights. Returns <see langword="true"/>
/// on success
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
/// </param>
/// <param name="senderChatId">
/// Unique identifier of the target sender chat
/// </param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class UnbanChatSenderChatRequest(ChatId chatId, long senderChatId)
    : RequestBase<bool>("unbanChatSenderChat"),
      IChatTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier of the target sender chat
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public long SenderChatId { get; } = senderChatId;
}

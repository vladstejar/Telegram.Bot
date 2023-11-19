using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to stop updating a live location message before
/// <see cref="Types.Location.LivePeriod"/> expires. On success the sent
/// <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="messageId">Identifier of the sent message</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class StopMessageLiveLocationRequest(ChatId chatId, int messageId)
    : RequestBase<Message>("stopMessageLiveLocation"),
      IChatTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Identifier of the sent message
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int MessageId { get; } = messageId;

    /// <inheritdoc cref="Abstractions.Documentation.InlineReplyMarkup"/>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit only the reply markup of messages. On success the edited
/// <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="messageId">Identifier of the message to edit</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditMessageReplyMarkupRequest(ChatId chatId, int messageId)
    : RequestBase<Message>("editMessageReplyMarkup"),
      IChatTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Identifier of the message to edit
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int MessageId { get; } = messageId;

    /// <inheritdoc cref="Documentation.InlineReplyMarkup"/>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

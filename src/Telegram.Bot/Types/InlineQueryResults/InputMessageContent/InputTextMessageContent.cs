using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents the content of a text message to be sent as the result of an
/// <see cref="InlineQuery">inline query</see>.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InputTextMessageContent : InputMessageContent
{
    /// <summary>
    /// Text of the message to be sent, 1-4096 characters
    /// </summary>
    [DataMember(IsRequired = true)]
    public string MessageText { get; }

    /// <summary>
    /// Optional. Mode for
    /// <a href="https://core.telegram.org/bots/api#formatting-options">parsing entities</a> in the message
    /// text. See formatting options for more details.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in message text, which can be specified
    /// instead of <see cref="ParseMode"/>
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? Entities { get; set; } // ToDo: add test

    /// <summary>
    /// Optional. Disables link previews for links in the sent message
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableWebPagePreview { get; set; }

    /// <summary>
    /// Initializes a new input text message content
    /// </summary>
    /// <param name="messageText">The text of the message</param>
    public InputTextMessageContent(string messageText)
    {
        MessageText = messageText;
    }
}

using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents the content of a text message to be sent as the result of an
/// <see cref="InlineQuery">inline query</see>.
/// </summary>
/// <remarks>
/// Initializes a new input text message content
/// </remarks>
/// <param name="messageText">The text of the message</param>
public class InputTextMessageContent(string messageText) : InputMessageContent
{
    /// <summary>
    /// Text of the message to be sent, 1-4096 characters
    /// </summary>
    public string MessageText { get; } = messageText;

    /// <summary>
    /// Optional. Mode for
    /// <a href="https://core.telegram.org/bots/api#formatting-options">parsing entities</a> in the message
    /// text. See formatting options for more details.
    /// </summary>
    public ParseMode? ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in message text, which can be specified
    /// instead of <see cref="ParseMode"/>
    /// </summary>
    public MessageEntity[]? Entities { get; set; } // ToDo: add test

    /// <summary>
    /// Optional. Disables link previews for links in the sent message
    /// </summary>
    public bool? DisableWebPagePreview { get; set; }
}

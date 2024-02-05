using System.Collections.Generic;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit text and game messages. On success the edited <see cref="Message"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class EditMessageTextRequest : RequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Identifier of the message to edit
    /// </summary>
    [DataMember(IsRequired = true)]
    public int MessageId { get; }

    /// <summary>
    /// New text of the message, 1-4096 characters after entities parsing
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Text { get; }

    /// <inheritdoc cref="Documentation.ParseMode"/>
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.Entities"/>
    [DataMember(EmitDefaultValue = false)]
    public IEnumerable<MessageEntity>? Entities { get; set; }

    /// <summary>
    /// Disables link previews for links in this message
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableWebPagePreview { get; set; }

    /// <inheritdoc cref="Documentation.ReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with chatId, messageId and text
    /// </summary>
    /// <param name="chatId">
    /// Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="messageId">Identifier of the message to edit</param>
    /// <param name="text">New text of the message, 1-4096 characters after entities parsing</param>
    public EditMessageTextRequest(ChatId chatId, int messageId, string text)
        : base("editMessageText")
    {
        ChatId = chatId;
        MessageId = messageId;
        Text = text;
    }
}

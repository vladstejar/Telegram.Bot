using System.Collections.Generic;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit text and game messages. On success <see langword="true"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class EditInlineMessageTextRequest : RequestBase<bool>
{
    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    [DataMember(IsRequired = true)]
    public string InlineMessageId { get; }

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
    /// Initializes a new request with inlineMessageId and new text
    /// </summary>
    /// <param name="inlineMessageId">Identifier of the inline message</param>
    /// <param name="text">New text of the message, 1-4096 characters after entities parsing</param>
    public EditInlineMessageTextRequest(string inlineMessageId, string text)
        : base("editMessageText")
    {
        InlineMessageId = inlineMessageId;
        Text = text;
    }
}

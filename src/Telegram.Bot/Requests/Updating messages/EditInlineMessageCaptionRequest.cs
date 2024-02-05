using System.Collections.Generic;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit captions of messages. On success <see langword="true"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class EditInlineMessageCaptionRequest : RequestBase<bool>
{
    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    [DataMember(IsRequired = true)]
    public string InlineMessageId { get; }

    /// <summary>
    /// New caption of the message, 0-1024 characters after entities parsing
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode"/>
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities"/>
    [DataMember(EmitDefaultValue = false)]
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.ReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with inlineMessageId and new caption
    /// </summary>
    /// <param name="inlineMessageId">Identifier of the inline message</param>
    public EditInlineMessageCaptionRequest(string inlineMessageId)
        : base("editMessageCaption")
    {
        InlineMessageId = inlineMessageId;
    }
}

using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit animation, audio, document, photo, or video messages. If a message is
/// part of a message album, then it can be edited only to an audio for audio albums, only to a
/// document for document albums and to a photo or a video otherwise. Use a previously uploaded file
/// via its <see cref="InputFileId"/> or specify a URL. On success
/// <see langword="true"/> is returned.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class EditInlineMessageMediaRequest : RequestBase<bool>
{
    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string InlineMessageId { get; }

    /// <summary>
    /// A new media content of the message
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public InputMedia Media { get; }

    /// <inheritdoc cref="Documentation.InlineReplyMarkup"/>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with inlineMessageId and new media
    /// </summary>
    /// <param name="inlineMessageId">Identifier of the inline message</param>
    /// <param name="media">A new media content of the message</param>
    public EditInlineMessageMediaRequest(string inlineMessageId, InputMedia media)
        : base("editMessageMedia")
    {
        InlineMessageId = inlineMessageId;
        Media = media;
    }
}

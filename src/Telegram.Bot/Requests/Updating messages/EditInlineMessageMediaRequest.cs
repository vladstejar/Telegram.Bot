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
/// <param name="inlineMessageId">Identifier of the inline message</param>
/// <param name="media">A new media content of the message</param>
public class EditInlineMessageMediaRequest(string inlineMessageId, InputMedia media)
    : RequestBase<bool>("editMessageMedia")
{
    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    public string InlineMessageId { get; } = inlineMessageId;

    /// <summary>
    /// A new media content of the message
    /// </summary>
    public InputMedia Media { get; } = media;

    /// <inheritdoc cref="Documentation.InlineReplyMarkup"/>

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

using System.Net.Http;
using Telegram.Bot.Extensions;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to edit animation, audio, document, photo, or video messages. If a message is part
/// of a message album, then it can be edited only to an audio for audio albums, only to a
/// document for document albums and to a photo or a video otherwise. Use a previously uploaded
/// file via its <see cref="InputFileId"/> or specify a URL.
/// On success the edited <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="messageId">Identifier of the message to edit</param>
/// <param name="media">A new media content of the message</param>
public class EditMessageMediaRequest(ChatId chatId, int messageId, InputMedia media)
    : FileRequestBase<Message>("editMessageMedia"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Identifier of the message to edit
    /// </summary>
    public int MessageId { get; } = messageId;

    /// <summary>
    /// A new media content of the message
    /// </summary>
    public InputMedia Media { get; } = media;

    /// <inheritdoc cref="Documentation.InlineReplyMarkup"/>

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent()
    {
        if (Media.Media.FileType is not FileType.Stream &&
            Media is not IInputMediaThumb { Thumbnail.FileType: FileType.Stream })
        {
            return base.ToHttpContent();
        }

        var multipartContent = GenerateMultipartFormDataContent();

        if (Media.Media is InputFileStream file)
        {
            multipartContent.AddContentIfInputFile(file, file.FileName!);
        }
        if (Media is IInputMediaThumb { Thumbnail: InputFileStream thumbnail })
        {
            multipartContent.AddContentIfInputFile(thumbnail, thumbnail.FileName!);
        }

        return multipartContent;
    }
}

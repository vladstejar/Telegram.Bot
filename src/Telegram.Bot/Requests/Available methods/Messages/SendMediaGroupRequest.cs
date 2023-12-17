using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot.Extensions;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send a group of photos, videos, documents or audios as an album. Documents and
/// audio files can be only grouped in an album with messages of the same type. On success, an array
/// of <see cref="Message"/>s that were sent is returned.
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="media">An array describing messages to be sent, must include 2-10 items</param>
public class SendMediaGroupRequest(ChatId chatId, IEnumerable<IAlbumInputMedia> media)
    : FileRequestBase<Message[]>("sendMediaGroup"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// An array describing messages to be sent, must include 2-10 items
    /// </summary>
    public IEnumerable<IAlbumInputMedia> Media { get; } = media;

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc />
    public override HttpContent ToHttpContent()
    {
        var multipartContent = GenerateMultipartFormDataContent();

        foreach (var mediaItem in Media)
        {
            if (mediaItem is InputMedia { Media: InputFileStream file })
                multipartContent.AddContentIfInputFile(file, file.FileName!);

            if (mediaItem is IInputMediaThumb { Thumbnail: InputFileStream thumbnail })
                multipartContent.AddContentIfInputFile(thumbnail, thumbnail.FileName!);
        }

        return multipartContent;
    }
}

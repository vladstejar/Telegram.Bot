using System.Net.Http;
using Telegram.Bot.Extensions;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// As of <a href="https://telegram.org/blog/video-messages-and-telescope">v.4.0</a>,
/// Telegram clients support rounded square mp4 videos of up to 1 minute long. Use this method
/// to send video messages. On success, the sent <see cref="Message"/> is returned.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="videoNote">
/// Video note to send. Pass a <see cref="InputFileId"/> as String to send a video
/// note that exists on the Telegram servers (recommended) or upload a new video using
/// multipart/form-data. Sending video notes by a URL is currently unsupported
/// </param>
public class SendVideoNoteRequest(ChatId chatId, InputFile videoNote)
    : FileRequestBase<Message>("sendVideoNote"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Video note to send. Pass a <see cref="InputFileId"/> as String to send a video
    /// note that exists on the Telegram servers (recommended) or upload a new video using
    /// multipart/form-data. Sending video notes by a URL is currently unsupported
    /// </summary>
    public InputFile VideoNote { get; } = videoNote;

    /// <summary>
    /// Duration of sent video in seconds
    /// </summary>
    public int? Duration { get; set; }

    /// <summary>
    /// Video width and height, i.e. diameter of the video message
    /// </summary>
    public int? Length { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.Thumbnail"/>
    public InputFile? Thumbnail { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        VideoNote is InputFileStream || Thumbnail is InputFileStream
            ? GenerateMultipartFormDataContent("video_note", "thumbnail")
                .AddContentIfInputFile(media: VideoNote, name: "video_note")
                .AddContentIfInputFile(media: Thumbnail, name: "thumbnail")
            : base.ToHttpContent();
}

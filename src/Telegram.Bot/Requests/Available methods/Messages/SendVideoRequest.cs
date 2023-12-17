using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot.Extensions;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send video files, Telegram clients support mp4 videos (other formats may be
/// sent as <see cref="Document"/>). On success, the sent <see cref="Message"/> is returned.
/// Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="video">
/// Video to send. Pass a <see cref="InputFileId"/> as String to send a video that
/// exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to
/// get a video from the Internet, or upload a new video using multipart/form-data
/// </param>
public class SendVideoRequest(ChatId chatId, InputFile video)
    : FileRequestBase<Message>("sendVideo"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Video to send. Pass a <see cref="InputFileId"/> as String to send a video that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to
    /// get a video from the Internet, or upload a new video using multipart/form-data
    /// </summary>
    public InputFile Video { get; } = video;

    /// <summary>
    /// Duration of sent video in seconds
    /// </summary>
    public int? Duration { get; set; }

    /// <summary>
    /// Video width
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// Video height
    /// </summary>
    public int? Height { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.Thumbnail"/>
    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Video caption (may also be used when resending videos by file_id),
    /// 0-1024 characters after entities parsing
    /// </summary>
    public string? Caption { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ParseMode"/>
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.CaptionEntities"/>
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the photo needs to be covered with a spoiler animation
    /// </summary>
    public bool? HasSpoiler { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the uploaded video is suitable for streaming
    /// </summary>
    public bool? SupportsStreaming { get; set; }

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
        Video is InputFileStream || Thumbnail is InputFileStream
            ? GenerateMultipartFormDataContent("video", "thumbnail")
                .AddContentIfInputFile(media: Video, name: "video")
                .AddContentIfInputFile(media: Thumbnail, name: "thumbnail")
            : base.ToHttpContent();
}

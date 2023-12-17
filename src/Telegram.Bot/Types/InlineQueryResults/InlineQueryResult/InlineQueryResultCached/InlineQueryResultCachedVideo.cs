using JetBrains.Annotations;
using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a video file stored on the Telegram servers. By default, this video file will
/// be sent by the user with an optional caption. Alternatively, you can use
/// <see cref="InlineQueryResultCachedVideo.InputMessageContent"/> to send a message with
/// the specified content instead of the video.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="videoFileId">A valid file identifier for the video file</param>
/// <param name="title">Title of the result</param>
[PublicAPI]
public class InlineQueryResultCachedVideo(string id, string videoFileId, string title) : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be video
    /// </summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Video;

    /// <summary>
    /// A valid file identifier for the video file
    /// </summary>
    public string VideoFileId { get; } = videoFileId;

    /// <summary>
    /// Title for the result
    /// </summary>
    public string Title { get; } = title;

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    public string? Description { get; set; }

    /// <inheritdoc cref="Documentation.Caption" />
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    public InputMessageContent? InputMessageContent { get; set; }
}

using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a page containing an embedded video player or a video file. By default, this
/// video file will be sent by the user with an optional caption. Alternatively, you can use
/// <see cref="InlineQueryResultVideo.InputMessageContent"/> to send a message with the specified
/// content instead of the video.
/// </summary>
/// <remarks>
/// If an <see cref="InlineQueryResultVideo"/> message contains an embedded video (e.g., YouTube),
/// you <b>must</b> replace its content using <see cref="InlineQueryResultVideo.InputMessageContent"/>.
/// </remarks>
/// <param name="id">Unique identifier of this result</param>
/// <param name="videoUrl">A valid URL for the embedded video player</param>
/// <param name="thumbnailUrl">Url of the thumbnail for the result</param>
/// <param name="title">Title of the result</param>
/// <param name="inputMessageContent">
/// Content of the message to be sent instead of the video. This field is <b>required</b> if
/// <see cref="InlineQueryResultVideo"/> is used to send an HTML-page as a result
/// (e.g., a YouTube video).
/// </param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultVideo(
    string id,
    string videoUrl,
    string thumbnailUrl,
    string title,
    InputMessageContent? inputMessageContent = default) : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be video
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public override InlineQueryResultType Type => InlineQueryResultType.Video;

    /// <summary>
    /// A valid URL for the embedded video player or video file
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string VideoUrl { get; } = videoUrl;

    /// <summary>
    /// Mime type of the content of video url, “text/html” or “video/mp4”
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string MimeType { get; } = inputMessageContent is null
        ? "video/mp4"
        : "text/html";

    /// <summary>
    /// URL of the thumbnail (jpeg only) for the video
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string ThumbnailUrl { get; } = thumbnailUrl;

    /// <summary>
    /// Title for the result
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Title { get; } = title;

    /// <inheritdoc cref="Documentation.Caption" />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Video width
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? VideoWidth { get; set; }

    /// <summary>
    /// Optional. Video height
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? VideoHeight { get; set; }

    /// <summary>
    /// Optional. Video duration in seconds
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? VideoDuration { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Description { get; set; }

    /// <summary>
    /// Optional. Content of the message to be sent instead of the video. This field is
    /// <b>required</b> if <see cref="InlineQueryResultVideo"/> is used to send an
    /// HTML-page as a result (e.g., a YouTube video).
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMessageContent? InputMessageContent { get; set; } = inputMessageContent;
}

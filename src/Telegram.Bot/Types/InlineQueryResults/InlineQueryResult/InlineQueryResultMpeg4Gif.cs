using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound). By default, this
/// animated MPEG-4 file will be sent by the user with optional caption. Alternatively, you can use
/// <see cref="InlineQueryResultMpeg4Gif.InputMessageContent"/> to send a message with the specified
/// content instead of the animation.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultMpeg4Gif : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be mpeg4_gif
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Mpeg4Gif;

    /// <summary>
    /// A valid URL for the MP4 file. File size must not exceed 1MB
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Mpeg4Url { get; }

    /// <summary>
    /// Optional. Video width
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Mpeg4Width { get; set; }

    /// <summary>
    /// Optional. Video height
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Mpeg4Height { get; set; }

    /// <summary>
    /// Optional. Video duration
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Mpeg4Duration { get; set; }

    /// <summary>
    /// URL of the static (JPEG or GIF) or animated (MPEG4) thumbnail for the result
    /// </summary>
    [DataMember(IsRequired = true)]
    public string ThumbnailUrl { get; }

    /// <summary>
    /// Optional. MIME type of the thumbnail, must be one of “image/jpeg”, “image/gif”,
    /// or “video/mp4”. Defaults to “image/jpeg”
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? ThumbnailMimeType { get; set; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Title { get; set; }

    /// <inheritdoc cref="Documentation.Caption" />
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    [DataMember(EmitDefaultValue = false)]
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    /// <param name="id">Unique identifier of this result</param>
    /// <param name="mpeg4Url">A valid URL for the MP4 file. File size must not exceed 1MB.</param>
    /// <param name="thumbnailUrl">Url of the thumbnail for the result.</param>
    public InlineQueryResultMpeg4Gif(string id, string mpeg4Url, string thumbnailUrl)
        : base(id)
    {
        Mpeg4Url = mpeg4Url;
        ThumbnailUrl = thumbnailUrl;
    }
}

using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to an animated GIF file. By default, this animated GIF file will be sent by the
/// user with optional caption. Alternatively, you can use
/// <see cref="InlineQueryResultGif.InputMessageContent"/> to send a message with the
/// specified content instead of the animation.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultGif : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be GIF
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Gif;

    /// <summary>
    /// A valid URL for the GIF file. File size must not exceed 1MB
    /// </summary>
    [DataMember(IsRequired = true)]
    public string GifUrl { get; }

    /// <summary>
    /// Optional. Width of the GIF.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? GifWidth { get; set; }

    /// <summary>
    /// Optional. Height of the GIF.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? GifHeight { get; set; }

    /// <summary>
    /// Optional. Duration of the GIF.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? GifDuration { get; set; }

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
    /// <param name="gifUrl">Width of the GIF</param>
    /// <param name="thumbnailUrl">Url of the thumbnail for the result.</param>
    public InlineQueryResultGif(string id, string gifUrl, string thumbnailUrl)
        : base(id)
    {
        GifUrl = gifUrl;
        ThumbnailUrl = thumbnailUrl;
    }
}

using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a photo. By default, this photo will be sent by the user with optional caption.
/// Alternatively, you can use <see cref="InlineQueryResultPhoto.InputMessageContent"/> to send a message
/// with the specified content instead of the photo.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultPhoto : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be photo
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Photo;

    /// <summary>
    /// A valid URL of the photo. Photo must be in <b>jpeg</b> format. Photo size must not exceed 5MB
    /// </summary>
    [DataMember(IsRequired = true)]
    public string PhotoUrl { get; }

    /// <inheritdoc cref="Documentation.ThumbnailUrl" />
    [DataMember(IsRequired = true)]
    public string ThumbnailUrl { get; }

    /// <summary>
    /// Optional. Width of the photo
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? PhotoWidth { get; set; }

    /// <summary>
    /// Optional. Height of the photo
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? PhotoHeight { get; set; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Title { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Description { get; set; }

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
    /// Initializes a new inline query representing a link to a photo
    /// </summary>
    /// <param name="id">Unique identifier of this result</param>
    /// <param name="photoUrl">A valid URL of the photo. Photo size must not exceed 5MB.</param>
    /// <param name="thumbnailUrl">Optional. Url of the thumbnail for the result.</param>
    public InlineQueryResultPhoto(string id, string photoUrl, string thumbnailUrl)
        : base(id)
    {
        PhotoUrl = photoUrl;
        ThumbnailUrl = thumbnailUrl;
    }
}

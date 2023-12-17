using JetBrains.Annotations;
using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a photo. By default, this photo will be sent by the user with optional caption.
/// Alternatively, you can use <see cref="InlineQueryResultPhoto.InputMessageContent"/> to send a message
/// with the specified content instead of the photo.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="photoUrl">A valid URL of the photo. Photo size must not exceed 5MB.</param>
/// <param name="thumbnailUrl">Optional. Url of the thumbnail for the result.</param>
[PublicAPI]
public class InlineQueryResultPhoto(string id, string photoUrl, string thumbnailUrl) : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be photo
    /// </summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Photo;

    /// <summary>
    /// A valid URL of the photo. Photo must be in <b>jpeg</b> format. Photo size must not exceed 5MB
    /// </summary>
    public string PhotoUrl { get; } = photoUrl;

    /// <inheritdoc cref="Documentation.ThumbnailUrl" />
    public string ThumbnailUrl { get; } = thumbnailUrl;

    /// <summary>
    /// Optional. Width of the photo
    /// </summary>
    public int? PhotoWidth { get; set; }

    /// <summary>
    /// Optional. Height of the photo
    /// </summary>
    public int? PhotoHeight { get; set; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    public string? Title { get; set; }

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

using JetBrains.Annotations;
using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// Represents a general file to be sent
/// </summary>
/// <param name="media">File to send</param>
[PublicAPI]
public class InputMediaDocument(InputFile media) :
    InputMedia(media),
    IInputMediaThumb,
    IAlbumInputMedia
{
    /// <inheritdoc />
    public override InputMediaType Type => InputMediaType.Document;

    /// <inheritdoc />

    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Optional. Disables automatic server-side content type detection for files uploaded using
    /// multipart/form-data. Always true, if the document is sent as part of an album.
    /// </summary>
    public bool? DisableContentTypeDetection { get; set; }
}

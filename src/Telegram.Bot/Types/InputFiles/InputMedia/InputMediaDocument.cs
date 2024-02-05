using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// Represents a general file to be sent
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InputMediaDocument :
    InputMedia,
    IInputMediaThumb,
    IAlbumInputMedia
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override InputMediaType Type => InputMediaType.Document;

    /// <inheritdoc />
    [DataMember(EmitDefaultValue = false)]
    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Optional. Disables automatic server-side content type detection for files uploaded using
    /// multipart/form-data. Always true, if the document is sent as part of an album.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableContentTypeDetection { get; set; }

    /// <summary>
    /// Initializes a new document media to send with an <see cref="InputMedia"/>
    /// </summary>
    /// <param name="media">File to send</param>
    public InputMediaDocument(InputFile media)
        : base(media)
    { }
}

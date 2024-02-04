using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// Represents a photo to be sent
/// </summary>
public class InputMediaPhoto :
    InputMedia,
    IAlbumInputMedia
{
    /// <inheritdoc />
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public override InputMediaType Type => InputMediaType.Photo;

    /// <summary>
    /// Optional. Pass <see langword="true"/> if the photo needs to be covered with a spoiler animation
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? HasSpoiler { get; set; }

    /// <summary>
    /// Initializes a new photo media to send with an <see cref="InputFile"/>
    /// </summary>
    /// <param name="media">File to send</param>
    public InputMediaPhoto(InputFile media)
        : base(media)
    { }
}

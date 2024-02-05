using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// Represents a video to be sent
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InputMediaVideo :
    InputMedia,
    IInputMediaThumb,
    IAlbumInputMedia
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override InputMediaType Type => InputMediaType.Video;

    /// <inheritdoc />
    [DataMember(EmitDefaultValue = false)]
    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Optional. Video width
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Width { get; set; }

    /// <summary>
    /// Optional. Video height
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Height { get; set; }

    /// <summary>
    /// Optional. Video duration
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Duration { get; set; }

    /// <summary>
    /// Optional. Pass True, if the uploaded video is suitable for streaming
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? SupportsStreaming { get; set; }

    /// <summary>
    /// Optional. Pass <see langword="true"/> if the video needs to be covered with a spoiler animation
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? HasSpoiler { get; set; }

    /// <summary>
    /// Initializes a new video media to send with an <see cref="InputFile"/>
    /// </summary>
    /// <param name="media">File to send</param>
    public InputMediaVideo(InputFile media)
        : base(media)
    { }
}

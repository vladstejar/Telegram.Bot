using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// Represents an animation file (GIF or H.264/MPEG-4 AVC video without sound) to be sent.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InputMediaAnimation :
    InputMedia,
    IInputMediaThumb
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override InputMediaType Type => InputMediaType.Animation;

    /// <inheritdoc />
    [DataMember(EmitDefaultValue = false)]
    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Optional. Animation width
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Width { get; set; }

    /// <summary>
    /// Optional. Animation height
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Height { get; set; }

    /// <summary>
    /// Optional. Animation duration
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Duration { get; set; }

    /// <summary>
    /// Optional. Pass <see langword="true"/> if the animation needs to be covered with a spoiler animation
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? HasSpoiler { get; set; }

    /// <summary>
    /// Initializes a new animation media to send with an <see cref="InputFile"/>
    /// </summary>
    /// <param name="media">File to send</param>
    public InputMediaAnimation(InputFile media)
        : base(media)
    { }
}

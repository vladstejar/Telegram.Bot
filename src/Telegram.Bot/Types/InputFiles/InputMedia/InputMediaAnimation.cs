using JetBrains.Annotations;
using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// Represents an animation file (GIF or H.264/MPEG-4 AVC video without sound) to be sent.
/// </summary>
/// <param name="media">File to send</param>
[PublicAPI]
public class InputMediaAnimation(InputFile media) :
    InputMedia(media),
    IInputMediaThumb
{
    /// <inheritdoc />
    public override InputMediaType Type => InputMediaType.Animation;

    /// <inheritdoc />

    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Optional. Animation width
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// Optional. Animation height
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// Optional. Animation duration
    /// </summary>
    public int? Duration { get; set; }

    /// <summary>
    /// Optional. Pass <see langword="true"/> if the animation needs to be covered with a spoiler animation
    /// </summary>
    public bool? HasSpoiler { get; set; }
}

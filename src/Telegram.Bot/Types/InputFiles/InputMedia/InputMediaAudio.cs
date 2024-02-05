using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// Represents an audio file to be treated as music to be sent.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InputMediaAudio :
    InputMedia,
    IInputMediaThumb,
    IAlbumInputMedia
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override InputMediaType Type => InputMediaType.Audio;

    /// <inheritdoc />
    [DataMember(EmitDefaultValue = false)]
    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Optional. Duration of the audio in seconds
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Duration { get; set; }

    /// <summary>
    /// Optional. Performer of the audio
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Performer { get; set; }

    /// <summary>
    /// Optional. Title of the audio
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Title { get; set; }

    /// <summary>
    /// Initializes a new audio media to send with an <see cref="InputFile"/>
    /// </summary>
    /// <param name="media">File to send</param>
    public InputMediaAudio(InputFile media)
        : base(media)
    { }
}

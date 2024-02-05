namespace Telegram.Bot.Types;

/// <summary>
/// This object represents an audio file to be treated as music by the Telegram clients.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class Audio : FileBase
{
    /// <summary>
    /// Duration of the audio in seconds as defined by sender
    /// </summary>
    [DataMember(IsRequired = true)]
    public int Duration { get; set; }

    /// <summary>
    /// Optional. Performer of the audio as defined by sender or by audio tags
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Performer { get; set; }

    /// <summary>
    /// Optional. Title of the audio as defined by sender or by audio tags
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Title { get; set; }

    /// <summary>
    /// Optional. Original filename as defined by sender
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? FileName { get; set; }

    /// <summary>
    /// Optional. MIME type of the file as defined by sender
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? MimeType { get; set; }

    /// <summary>
    /// Optional. Thumbnail of the album cover to which the music file belongs
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public PhotoSize? Thumbnail { get; set; }
}

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a voice note.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class Voice : FileBase
{
    /// <summary>
    /// Duration of the audio in seconds as defined by sender
    /// </summary>
    [DataMember(IsRequired = true)]
    public int Duration { get; set; }

    /// <summary>
    /// Optional. MIME type of the file as defined by sender
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? MimeType { get; set; }
}

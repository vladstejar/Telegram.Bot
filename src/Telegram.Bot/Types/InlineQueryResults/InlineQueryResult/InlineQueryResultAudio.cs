using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to an MP3 audio file. By default, this audio file will be sent by the user.
/// Alternatively, you can use <see cref="InlineQueryResultAudio.InputMessageContent"/> to send
/// a message with the specified content instead of the audio.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultAudio : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be audio
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Audio;

    /// <summary>
    /// A valid URL for the audio file
    /// </summary>
    [DataMember(IsRequired = true)]
    public string AudioUrl { get; }

    /// <summary>
    /// Title
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; }

    /// <inheritdoc cref="Documentation.Caption" />
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Performer
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Performer { get; set; }

    /// <summary>
    /// Optional. Audio duration in seconds
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? AudioDuration { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    [DataMember(EmitDefaultValue = false)]
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    /// <param name="id">Unique identifier of this result</param>
    /// <param name="audioUrl">A valid URL for the audio file</param>
    /// <param name="title">Title of the result</param>
    public InlineQueryResultAudio(string id, string audioUrl, string title)
        : base(id)
    {
        AudioUrl = audioUrl;
        Title = title;
    }
}

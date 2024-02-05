using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to an MP3 audio file stored on the Telegram servers. By default, this audio
/// file will be sent by the user. Alternatively, you can use
/// <see cref="InlineQueryResultCachedAudio.InputMessageContent"/> to send a message with the
/// specified content instead of the audio.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultCachedAudio : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be audio
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Audio;

    /// <summary>
    /// A valid file identifier for the audio file
    /// </summary>
    [DataMember(IsRequired = true)]
    public string AudioFileId { get; }

    /// <inheritdoc cref="Documentation.Caption" />
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    [DataMember(EmitDefaultValue = false)]
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    /// <param name="id">Unique identifier of this result</param>
    /// <param name="audioFileId">A valid file identifier for the audio file</param>
    public InlineQueryResultCachedAudio(string id, string audioFileId)
        : base(id)
    {
        AudioFileId = audioFileId;
    }
}

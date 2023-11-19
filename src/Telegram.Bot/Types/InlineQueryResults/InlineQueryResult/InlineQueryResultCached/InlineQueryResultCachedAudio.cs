using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to an MP3 audio file stored on the Telegram servers. By default, this audio
/// file will be sent by the user. Alternatively, you can use
/// <see cref="InlineQueryResultCachedAudio.InputMessageContent"/> to send a message with the
/// specified content instead of the audio.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="audioFileId">A valid file identifier for the audio file</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultCachedAudio(string id, string audioFileId) : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be audio
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public override InlineQueryResultType Type => InlineQueryResultType.Audio;

    /// <summary>
    /// A valid file identifier for the audio file
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string AudioFileId { get; } = audioFileId;

    /// <inheritdoc cref="Documentation.Caption" />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMessageContent? InputMessageContent { get; set; }
}

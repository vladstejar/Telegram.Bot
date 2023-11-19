using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a voice message stored on the Telegram servers. By default, this voice
/// message will be sent by the user. Alternatively, you can use
/// <see cref="InlineQueryResultCachedVoice.InputMessageContent"/> to send a message
/// with the specified content instead of the voice message.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="fileId">A valid file identifier for the voice message</param>
/// <param name="title">Title of the result</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultCachedVoice(string id, string fileId, string title) : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be voice
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public override InlineQueryResultType Type => InlineQueryResultType.Voice;

    /// <summary>
    /// A valid file identifier for the voice message
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string VoiceFileId { get; } = fileId;

    /// <summary>
    /// Voice message title
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Title { get; } = title;

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

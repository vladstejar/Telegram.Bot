using JetBrains.Annotations;
using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a voice recording in an .OGG container encoded with OPUS. By default, this
/// voice recording will be sent by the user. Alternatively, you can use
/// <see cref="InlineQueryResultVoice.InputMessageContent"/> to send a message with the specified
/// content instead of the voice message.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="voiceUrl">A valid URL for the voice recording</param>
/// <param name="title">Title of the result</param>
[PublicAPI]
public class InlineQueryResultVoice(string id, string voiceUrl, string title) : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be voice
    /// </summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Voice;

    /// <summary>
    /// A valid URL for the voice recording
    /// </summary>
    public string VoiceUrl { get; } = voiceUrl;

    /// <summary>
    /// Recording title
    /// </summary>
    public string Title { get; } = title;

    /// <inheritdoc cref="Documentation.Caption" />
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary>
    /// Optional. Recording duration in seconds
    /// </summary>
    public int? VoiceDuration { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    public InputMessageContent? InputMessageContent { get; set; }
}

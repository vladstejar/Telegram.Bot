using JetBrains.Annotations;
using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a file stored on the Telegram servers. By default, this file will be sent
/// by the user with an optional caption. Alternatively, you can use
/// <see cref="InlineQueryResultCachedDocument.InputMessageContent"/> to send a message with the
/// specified content instead of the file.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="documentFileId">A valid file identifier for the file</param>
/// <param name="title">Title of the result</param>
[PublicAPI]
public class InlineQueryResultCachedDocument(string id, string documentFileId, string title)
    : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be document
    /// </summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Document;

    /// <summary>
    /// Title for the result
    /// </summary>
    public string Title { get; } = title;

    /// <summary>
    /// A valid file identifier for the file
    /// </summary>
    public string DocumentFileId { get; } = documentFileId;

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    public string? Description { get; set; }

    /// <inheritdoc cref="Documentation.Caption" />
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    public InputMessageContent? InputMessageContent { get; set; }
}

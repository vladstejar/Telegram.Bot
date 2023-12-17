using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to an article or web page.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="title">Title of the result</param>
/// <param name="inputMessageContent">Content of the message to be sent</param>
[PublicAPI]
public class InlineQueryResultArticle(string id, string title, InputMessageContent inputMessageContent)
    : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be article
    /// </summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Article;

    /// <summary>
    /// Title of the result
    /// </summary>
    public string Title { get; } = title;

    /// <summary>
    /// Content of the message to be sent
    /// </summary>
    public InputMessageContent InputMessageContent { get; } = inputMessageContent;

    /// <summary>
    /// Optional. URL of the result.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Optional. Pass <see langword="true"/>, if you don't want the URL to be shown in the message.
    /// </summary>
    public bool? HideUrl { get; set; }

    /// <summary>
    /// Optional. Short description of the result.
    /// </summary>
    public string? Description { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailUrl" />

    public string? ThumbnailUrl { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailWidth" />

    public int? ThumbnailWidth { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailHeight" />

    public int? ThumbnailHeight { get; set; }
}

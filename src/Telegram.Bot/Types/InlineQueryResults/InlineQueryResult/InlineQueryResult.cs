using JetBrains.Annotations;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Base Class for inline results send in response to an <see cref="InlineQuery"/>
/// </summary>
/// <param name="id">Unique identifier for this result, 1-64 Bytes</param>
[PublicAPI]
public abstract class InlineQueryResult(string id)
{
    /// <summary>
    /// Type of the result
    /// </summary>
    public abstract InlineQueryResultType Type { get; }

    /// <summary>
    /// Unique identifier for this result, 1-64 Bytes
    /// </summary>
    public string Id { get; } = id;

    /// <summary>
    /// Optional. Inline keyboard attached to the message
    /// </summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}

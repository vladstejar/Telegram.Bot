using System.Collections.Generic;
using Telegram.Bot.Types.InlineQueryResults;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send answers to an inline query. On success, <see langword="true"/> is returned.
/// </summary>
/// <remarks>
/// No more than <b>50</b> results per query are allowed.
/// </remarks>
/// <param name="inlineQueryId">Unique identifier for the answered query</param>
/// <param name="results">An array of results for the inline query</param>
public class AnswerInlineQueryRequest(string inlineQueryId, IEnumerable<InlineQueryResult> results)
    : RequestBase<bool>("answerInlineQuery")
{
    /// <summary>
    /// Unique identifier for the answered query
    /// </summary>
    public string InlineQueryId { get; } = inlineQueryId;

    /// <summary>
    /// An array of results for the inline query
    /// </summary>
    public IEnumerable<InlineQueryResult> Results { get; } = results;

    /// <summary>
    /// The maximum amount of time in seconds that the result of the
    /// inline query may be cached on the server. Defaults to 300
    /// </summary>
    public int? CacheTime { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if results may be cached on the server side only for the user that sent
    /// the query. By default, results may be returned to any user who sends the same query
    /// </summary>
    public bool? IsPersonal { get; set; }

    /// <summary>
    /// Pass the offset that a client should send in the next query with the same text to
    /// receive more results. Pass an empty string if there are no more results or if you
    /// don't support pagination. Offset length can't exceed 64 bytes
    /// </summary>
    public string? NextOffset { get; set; }

    /// <summary>
    /// A JSON-serialized object describing a button to be shown above inline query results
    /// </summary>
    public InlineQueryResultsButton? Button { get; set; }
}

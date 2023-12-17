

// ReSharper disable once CheckNamespace

using JetBrains.Annotations;

namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a sticker stored on the Telegram servers. By default, this sticker will
/// be sent by the user. Alternatively, you can use
/// <see cref="InlineQueryResultCachedSticker.InputMessageContent"/> to send a message with
/// the specified content instead of the sticker.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="stickerFileId">A valid file identifier of the sticker</param>
[PublicAPI]
public class InlineQueryResultCachedSticker(string id, string stickerFileId) : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be sticker
    /// </summary>
    public override InlineQueryResultType Type => InlineQueryResultType.Sticker;

    /// <summary>
    /// A valid file identifier of the sticker
    /// </summary>
    public string StickerFileId { get; } = stickerFileId;

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    public InputMessageContent? InputMessageContent { get; set; }
}

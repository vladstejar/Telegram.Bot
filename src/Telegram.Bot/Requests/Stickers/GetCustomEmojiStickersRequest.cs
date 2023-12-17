using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get information about custom emoji stickers by their identifiers.
/// Returns an Array of <see cref="Sticker"/> objects.
/// </summary>
/// <param name="customEmojiIds">List of custom emoji identifiers. At most 200 custom emoji
/// identifiers can be specified.</param>
public class GetCustomEmojiStickersRequest(IEnumerable<string> customEmojiIds)
    : RequestBase<Sticker[]>("getCustomEmojiStickers")
{
    /// <summary>
    /// List of custom emoji identifiers. At most 200 custom emoji identifiers can be specified.
    /// </summary>
    public IEnumerable<string> CustomEmojiIds { get; } = customEmojiIds;
}

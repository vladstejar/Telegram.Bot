using System.Collections.Generic;

namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the list of emoji assigned to a regular or custom emoji sticker.
/// The sticker must belong to a sticker set created by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="sticker"><see cref="InputFileId">File identifier</see> of the sticker</param>
/// <param name="emojiList">A JSON-serialized list of 1-20 emoji associated with the sticker</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetStickerEmojiListRequest(InputFileId sticker, IEnumerable<string> emojiList)
    : RequestBase<bool>("setStickerEmojiList")
{
    /// <summary>
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public InputFileId Sticker { get; } = sticker;

    /// <summary>
    /// A JSON-serialized list of 1-20 emoji associated with the sticker
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public IEnumerable<string> EmojiList { get; } = emojiList;
}

namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set the thumbnail of a custom emoji sticker set.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="name">
/// Sticker set name
/// </param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetCustomEmojiStickerSetThumbnailRequest(string name)
    : RequestBase<bool>("setCustomEmojiStickerSetThumbnail")
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Name { get; } = name;

    /// <summary>
    /// Optional. Custom emoji identifier of a <see cref="Sticker"/> from the <see cref="StickerSet"/>;
    /// pass an <see langword="null"/> to drop the thumbnail and use the first sticker as the thumbnail.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? CustomEmojiId { get; set; }
}

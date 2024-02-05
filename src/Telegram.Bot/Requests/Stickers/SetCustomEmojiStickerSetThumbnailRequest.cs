namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set the thumbnail of a custom emoji sticker set.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SetCustomEmojiStickerSetThumbnailRequest : RequestBase<bool>
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Name { get; }

    /// <summary>
    /// Optional. Custom emoji identifier of a <see cref="Sticker"/> from the <see cref="StickerSet"/>;
    /// pass an <see langword="null"/> to drop the thumbnail and use the first sticker as the thumbnail.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? CustomEmojiId { get; set; }

    /// <summary>
    /// Initializes a new request with name
    /// </summary>
    /// <param name="name">
    /// Sticker set name
    /// </param>
    public SetCustomEmojiStickerSetThumbnailRequest(string name)
        : base("setCustomEmojiStickerSetThumbnail")
    {
        Name = name;
    }
}

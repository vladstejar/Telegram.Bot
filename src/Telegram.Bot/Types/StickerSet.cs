using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a sticker set.
/// <a href="https://core.telegram.org/bots/api#stickerset"/>
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class StickerSet
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Sticker set title
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; set; } = default!;

    /// <summary>
    /// Type of stickers in the set
    /// </summary>
    [DataMember(IsRequired = true)]
    public StickerType StickerType { get; set; } = default!;

    /// <summary>
    /// <see langword="true"/>, if the sticker set contains <see cref="StickerFormat.Animated">animated stickers</see>
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool IsAnimated { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the sticker set contains <see cref="StickerFormat.Video">video stickers</see>
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool IsVideo { get; set; }

    /// <summary>
    /// List of all set stickers
    /// </summary>
    [DataMember(IsRequired = true)]
    public Sticker[] Stickers { get; set; } = default!;

    /// <summary>
    /// Optional. Sticker set thumbnail in the .WEBP, .TGS, or .WEBM format
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public PhotoSize? Thumbnail { get; set; }
}

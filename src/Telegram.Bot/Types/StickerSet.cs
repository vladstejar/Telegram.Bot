using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a sticker set.
/// <a href="https://core.telegram.org/bots/api#stickerset"/>
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class StickerSet
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Name { get; set; } = default!;

    /// <summary>
    /// Sticker set title
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Title { get; set; } = default!;

    /// <summary>
    /// Type of stickers in the set
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public StickerType StickerType { get; set; } = default!;

    /// <summary>
    /// <see langword="true"/>, if the sticker set contains <see cref="StickerFormat.Animated">animated stickers</see>
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public bool IsAnimated { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the sticker set contains <see cref="StickerFormat.Video">video stickers</see>
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public bool IsVideo { get; set; }

    /// <summary>
    /// List of all set stickers
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public Sticker[] Stickers { get; set; } = default!;

    /// <summary>
    /// Optional. Sticker set thumbnail in the .WEBP, .TGS, or .WEBM format
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public PhotoSize? Thumbnail { get; set; }
}

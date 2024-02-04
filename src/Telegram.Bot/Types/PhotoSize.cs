namespace Telegram.Bot.Types;

/// <summary>
/// This object represents one size of a photo or a <see cref="Document">file</see> / <see cref="Sticker">sticker</see> thumbnail.
/// </summary>
/// <remarks>A missing thumbnail for a file (or sticker) is presented as an empty object.</remarks>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class PhotoSize : FileBase
{
    /// <summary>
    /// Photo width
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int Width { get; set; }

    /// <summary>
    /// Photo height
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int Height { get; set; }
}

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a <a href="https://telegram.org/blog/video-messages-and-telescope">video message</a>
/// (available in Telegram apps as of
/// <a href="https://telegram.org/blog/video-messages-and-telescope">v.4.0</a>).
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class VideoNote : FileBase
{
    /// <summary>
    /// Video width and height (diameter of the video message) as defined by sender
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int Length { get; set; }

    /// <summary>
    /// Duration of the video in seconds as defined by sender
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int Duration { get; set; }

    /// <summary>
    /// Optional. Video thumbnail
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public PhotoSize? Thumbnail { get; set; }
}

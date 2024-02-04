namespace Telegram.Bot.Types;

/// <summary>
/// This object represent a user's profile pictures.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class UserProfilePhotos
{
    /// <summary>
    /// Total number of profile pictures the target user has
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int TotalCount { get; set; }

    /// <summary>
    /// Requested profile pictures (in up to 4 sizes each)
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public PhotoSize[][] Photos { get; set; } = default!;
}

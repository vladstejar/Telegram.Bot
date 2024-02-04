namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a file ready to be downloaded. The file can be downloaded via <see cref="TelegramBotClientExtensions.GetFileAsync"/>.
/// It is guaranteed that the link will be valid for at least 1 hour. When the link expires, a new one can be requested by calling <see cref="TelegramBotClientExtensions.GetFileAsync"/>.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class File : FileBase
{
    /// <summary>
    /// Optional. File path. Use <see cref="TelegramBotClientExtensions.GetFileAsync"/> to get the file.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? FilePath { get; set; }
}

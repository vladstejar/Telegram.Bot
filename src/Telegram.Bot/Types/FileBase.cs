namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a file ready to be downloaded. The file can be downloaded via
/// <see cref="TelegramBotClientExtensions.GetFileAsync"/>. It is guaranteed that the link will be valid for
/// at least 1 hour. When the link expires, a new one can be requested by calling
/// <see cref="TelegramBotClientExtensions.GetFileAsync"/>.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public abstract class FileBase
{
    /// <summary>
    /// Identifier for this file, which can be used to download or reuse the file
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string FileId { get; set; } = default!;

    /// <summary>
    /// Unique identifier for this file, which is supposed to be the same over time and for different bots.
    /// Can't be used to download or reuse the file.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string FileUniqueId { get; set; } = default!;

    /// <summary>
    /// Optional. File size
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public long? FileSize { get; set; }
}

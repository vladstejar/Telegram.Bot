namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a file ready to be downloaded. The file can be downloaded via
/// <see cref="TelegramBotClientExtensions.GetFileAsync"/>. It is guaranteed that the link will be valid for
/// at least 1 hour. When the link expires, a new one can be requested by calling
/// <see cref="TelegramBotClientExtensions.GetFileAsync"/>.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#else
[JsonPolymorphic(TypeDiscriminatorPropertyName = null)]
[JsonDerivedType(typeof(Animation))]
[JsonDerivedType(typeof(Audio))]
[JsonDerivedType(typeof(Document))]
[JsonDerivedType(typeof(File))]
[JsonDerivedType(typeof(Passport.PassportFile))]
[JsonDerivedType(typeof(PhotoSize))]
[JsonDerivedType(typeof(Sticker))]
[JsonDerivedType(typeof(Video))]
[JsonDerivedType(typeof(VideoNote))]
[JsonDerivedType(typeof(Voice))]
#endif
[DataContract]
public abstract class FileBase
{
    /// <summary>
    /// Identifier for this file, which can be used to download or reuse the file
    /// </summary>
    [DataMember(IsRequired = true)]
    public string FileId { get; set; } = default!;

    /// <summary>
    /// Unique identifier for this file, which is supposed to be the same over time and for different bots.
    /// Can't be used to download or reuse the file.
    /// </summary>
    [DataMember(IsRequired = true)]
    public string FileUniqueId { get; set; } = default!;

    /// <summary>
    /// Optional. File size
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public long? FileSize { get; set; }
}

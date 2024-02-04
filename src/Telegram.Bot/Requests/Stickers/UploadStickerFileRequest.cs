using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using File = Telegram.Bot.Types.File;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to upload a file with a sticker for later use in the
/// <see cref="CreateNewStickerSetRequest"/> and <see cref="AddStickerToSetRequest"/>
/// methods (the file can be used multiple times).
/// Returns the uploaded <see cref="File"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class UploadStickerFileRequest : FileRequestBase<File>, IUserTargetable
{
    /// <inheritdoc />
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public long UserId { get; }

    /// <summary>
    /// A file with the sticker in .WEBP, .PNG, .TGS, or .WEBM format.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public InputFileStream Sticker { get; }

    /// <summary>
    /// Format of the sticker
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public StickerFormat StickerFormat { get; }

    /// <summary>
    /// Initializes a new request with userId, sticker and stickerFormat
    /// </summary>
    /// <param name="userId">
    /// User identifier of sticker file owner
    /// </param>
    /// <param name="sticker">
    /// A file with the sticker in .WEBP, .PNG, .TGS, or .WEBM format.
    /// </param>
    /// <param name="stickerFormat">
    /// Format of the sticker
    /// </param>
    public UploadStickerFileRequest(long userId, InputFileStream sticker, StickerFormat stickerFormat)
        : base("uploadStickerFile")
    {
        UserId = userId;
        Sticker = sticker;
        StickerFormat = stickerFormat;
    }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent()
        => ToMultipartFormDataContent(fileParameterName: "sticker", inputFile: Sticker);
}

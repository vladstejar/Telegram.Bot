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
/// <param name="userId">
/// User identifier of sticker file owner
/// </param>
/// <param name="sticker">
/// A file with the sticker in .WEBP, .PNG, .TGS, or .WEBM format.
/// </param>
/// <param name="stickerFormat">
/// Format of the sticker
/// </param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class UploadStickerFileRequest(long userId, InputFileStream sticker, StickerFormat stickerFormat)
    : FileRequestBase<File>("uploadStickerFile"),
      IUserTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public long UserId { get; } = userId;

    /// <summary>
    /// A file with the sticker in .WEBP, .PNG, .TGS, or .WEBM format.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public InputFileStream Sticker { get; } = sticker;

    /// <summary>
    /// Format of the sticker
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public StickerFormat StickerFormat { get; } = stickerFormat;

    /// <inheritdoc />
    public override HttpContent? ToHttpContent()
        => ToMultipartFormDataContent(fileParameterName: "sticker", inputFile: Sticker);
}

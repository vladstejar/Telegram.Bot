using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to add a new sticker to a set created by the bot.
/// The format of the added sticker must match the format of the other stickers in the set.
/// <list type="bullet">
/// <item>
/// Emoji sticker sets can have up to 200 stickers.
/// </item>
/// <item>
/// Animated and video sticker sets can have up to 50 stickers.
/// </item>
/// <item>
/// Static sticker sets can have up to 120 stickers.
/// </item>
/// </list>
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="userId">
/// User identifier
/// </param>
/// <param name="name">
/// Sticker set name
/// </param>
/// <param name="sticker">
/// A JSON-serialized object with information about the added sticker.
/// If exactly the same sticker had already been added to the set, then the set isn't changed.
/// </param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AddStickerToSetRequest(
    long userId,
    string name,
    InputSticker sticker)
        : FileRequestBase<bool>("addStickerToSet"),
          IUserTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public long UserId { get; } = userId;

    /// <summary>
    /// Sticker set name
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Name { get; } = name;

    /// <summary>
    /// A JSON-serialized object with information about the added sticker.
    /// If exactly the same sticker had already been added to the set, then the set isn't changed.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public InputSticker Sticker { get; } = sticker;

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        Sticker.Sticker switch
        {
            InputFileStream stickerFile => ToMultipartFormDataContent(fileParameterName: stickerFile.FileName!, inputFile: stickerFile),
            _                           => base.ToHttpContent()
        };
}

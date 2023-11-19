// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get a sticker set. On success, a <see cref="StickerSet"/> object is returned.
/// </summary>
/// <param name="name">Name of the sticker set</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetStickerSetRequest(string name) : RequestBase<StickerSet>("getStickerSet")
{
    /// <summary>
    /// Name of the sticker set
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Name { get; } = name;
}

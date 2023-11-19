namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set the title of a created sticker set.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="name">
/// Sticker set name
/// </param>
/// <param name="title">
/// Sticker set title, 1-64 characters
/// </param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetStickerSetTitleRequest(string name, string title) : RequestBase<bool>("setStickerSetTitle")
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Name { get; } = name;

    /// <summary>
    /// Sticker set title, 1-64 characters
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Title { get; } = title;
}

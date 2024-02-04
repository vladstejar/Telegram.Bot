namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set the title of a created sticker set.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class SetStickerSetTitleRequest : RequestBase<bool>
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Name { get; }

    /// <summary>
    /// Sticker set title, 1-64 characters
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Title { get; }

    /// <summary>
    /// Initializes a new request with name and title
    /// </summary>
    /// <param name="name">
    /// Sticker set name
    /// </param>
    /// <param name="title">
    /// Sticker set title, 1-64 characters
    /// </param>
    public SetStickerSetTitleRequest(string name, string title)
        : base("setStickerSetTitle")
    {
        Name = name;
        Title = title;
    }
}

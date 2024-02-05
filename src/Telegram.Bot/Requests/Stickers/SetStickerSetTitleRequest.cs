namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set the title of a created sticker set.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SetStickerSetTitleRequest : RequestBase<bool>
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Name { get; }

    /// <summary>
    /// Sticker set title, 1-64 characters
    /// </summary>
    [DataMember(IsRequired = true)]
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

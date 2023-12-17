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
public class SetStickerSetTitleRequest(string name, string title) : RequestBase<bool>("setStickerSetTitle")
{
    /// <summary>
    /// Sticker set name
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// Sticker set title, 1-64 characters
    /// </summary>
    public string Title { get; } = title;
}

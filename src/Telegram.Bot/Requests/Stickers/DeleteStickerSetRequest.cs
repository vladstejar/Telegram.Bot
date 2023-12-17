namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to delete a sticker set that was created by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="name">
/// Sticker set name
/// </param>
public class DeleteStickerSetRequest(string name) : RequestBase<bool>("deleteStickerSet")
{
    //
    /// <summary>
    /// Sticker set name
    /// </summary>
    public string Name { get; } = name;
}

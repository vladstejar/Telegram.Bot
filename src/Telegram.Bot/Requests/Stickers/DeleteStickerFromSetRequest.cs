// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to delete a sticker from a set created by the bot. Returns <see langword="true"/> on success.
/// </summary>
/// <param name="sticker">
/// <see cref="InputFileId">File identifier</see> of the sticker
/// </param>
public class DeleteStickerFromSetRequest(InputFileId sticker) : RequestBase<bool>("deleteStickerFromSet")
{
    /// <summary>
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </summary>
    public InputFileId Sticker { get; } = sticker;
}

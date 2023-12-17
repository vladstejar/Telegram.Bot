using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set a new group sticker set for a supergroup. The bot must be an administrator in
/// the chat for this to work and must have the appropriate admin rights. Use the field
/// <see cref="Chat.CanSetStickerSet"/> optionally returned in <see cref="GetChatRequest"/> requests to
/// check if the bot can use this method. Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="stickerSetName">Name of the sticker set to be set as the group sticker set</param>
public class SetChatStickerSetRequest(ChatId chatId, string stickerSetName)
    : RequestBase<bool>("setChatStickerSet"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Name of the sticker set to be set as the group sticker set
    /// </summary>
    public string StickerSetName { get; } = stickerSetName;
}

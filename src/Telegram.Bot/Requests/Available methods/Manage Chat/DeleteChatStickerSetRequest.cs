using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to delete a group sticker set from a supergroup. The bot must be an administrator
/// in the chat for this to work and must have the appropriate admin rights. Use the field
/// <see cref="Types.Chat.CanSetStickerSet"/> optionally returned in <see cref="GetChatRequest"/>
/// requests to check if the bot can use this method. Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
public class DeleteChatStickerSetRequest(ChatId chatId)
    : RequestBase<bool>("deleteChatStickerSet"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;
}

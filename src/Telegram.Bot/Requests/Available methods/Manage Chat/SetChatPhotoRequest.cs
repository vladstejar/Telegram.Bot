using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set a new profile photo for the chat. Photos can't be changed for private
/// chats. The bot must be an administrator in the chat for this to work and must have the appropriate
/// admin rights. Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="photo">New chat photo, uploaded using multipart/form-data</param>
public class SetChatPhotoRequest(ChatId chatId, InputFileStream photo)
    : FileRequestBase<bool>("setChatPhoto"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// New chat photo, uploaded using multipart/form-data
    /// </summary>
    public InputFileStream Photo { get; } = photo;

    /// <inheritdoc />
    public override HttpContent ToHttpContent()
        => ToMultipartFormDataContent("photo", Photo);
}

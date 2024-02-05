using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to set a new profile photo for the chat. Photos can't be changed for private
/// chats. The bot must be an administrator in the chat for this to work and must have the appropriate
/// admin rights. Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SetChatPhotoRequest : FileRequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// New chat photo, uploaded using multipart/form-data
    /// </summary>
    [DataMember(IsRequired = true)]
    public InputFileStream Photo { get; }

    /// <summary>
    /// Initializes a new request with chatId and photo
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="photo">New chat photo, uploaded using multipart/form-data</param>
    public SetChatPhotoRequest(ChatId chatId, InputFileStream photo)
        : base("setChatPhoto")
    {
        ChatId = chatId;
        Photo = photo;
    }

    /// <inheritdoc />
    public override HttpContent ToHttpContent()
        => ToMultipartFormDataContent("photo", Photo);
}

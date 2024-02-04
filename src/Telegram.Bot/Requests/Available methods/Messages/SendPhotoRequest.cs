using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send photos. On success, the sent <see cref="Message"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class SendPhotoRequest : FileRequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public ChatId ChatId { get; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Photo to send. Pass a <see cref="InputFileId"/> as String to send a photo that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to
    /// get a photo from the Internet, or upload a new photo using multipart/form-data. The photo
    /// must be at most 10 MB in size. The photo's width and height must not exceed 10000 in total.
    /// Width and height ratio must be at most 20
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public InputFile Photo { get; }

    /// <summary>
    /// Photo caption (may also be used when resending photos by <see cref="InputFileId"/>),
    /// 0-1024 characters after entities parsing
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? Caption { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ParseMode"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.CaptionEntities"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the photo needs to be covered with a spoiler animation
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? HasSpoiler { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with chatId and photo
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="photo">
    /// Photo to send. Pass a <see cref="InputFileId"/> as String to send a photo that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to
    /// get a photo from the Internet, or upload a new photo using multipart/form-data. The photo
    /// must be at most 10 MB in size. The photo's width and height must not exceed 10000 in total.
    /// Width and height ratio must be at most 20</param>
    public SendPhotoRequest(ChatId chatId, InputFile photo)
        : base("sendPhoto")
    {
        ChatId = chatId;
        Photo = photo;
    }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        Photo switch
        {
            InputFileStream photo => ToMultipartFormDataContent(fileParameterName: "photo", inputFile: photo),
            _               => base.ToHttpContent()
        };
}

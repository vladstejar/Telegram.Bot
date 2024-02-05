using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send audio files, if you want Telegram clients to display the file as a playable
/// voice message. For this to work, your audio must be in an .OGG file encoded with OPUS (other
/// formats may be sent as <see cref="Audio"/> or <see cref="Document"/>). On success, the sent
/// <see cref="Message"/> is returned. Bots can currently send voice messages of up to 50 MB in size,
/// this limit may be changed in the future.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SendVoiceRequest : FileRequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Audio file to send. Pass a <see cref="InputFileId"/> as String to send a file that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get
    /// a file from the Internet, or upload a new one using multipart/form-data
    /// </summary>
    [DataMember(IsRequired = true)]
    public InputFile Voice { get; }

    /// <summary>
    /// Voice message caption, 0-1024 characters after entities parsing
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ParseMode"/>
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.CaptionEntities"/>
    [DataMember(EmitDefaultValue = false)]
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <summary>
    /// Duration of the voice message in seconds
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Duration { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    [DataMember(EmitDefaultValue = false)]
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with chatId and voice
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="voice">
    /// Audio file to send. Pass a <see cref="InputFileId"/> as String to send a file
    /// that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram
    /// to get a file from the Internet, or upload a new one using multipart/form-data
    /// </param>
    public SendVoiceRequest(ChatId chatId, InputFile voice)
        : base("sendVoice")
    {
        ChatId = chatId;
        Voice = voice;
    }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        Voice switch
        {
            InputFileStream voice => ToMultipartFormDataContent(fileParameterName: "voice", inputFile: voice),
            _               => base.ToHttpContent()
        };
}

using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot.Extensions;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send general files. On success, the sent <see cref="Message"/>
/// is returned. Bots can currently send files of any type of up to 50 MB in size,
/// this limit may be changed in the future.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SendDocumentRequest : FileRequestBase<Message>, IChatTargetable
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
    /// File to send. Pass a <see cref="InputFileId"/> as String to send a file that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram
    /// to get a file from the Internet, or upload a new one using multipart/form-data
    /// </summary>
    [DataMember(IsRequired = true)]
    public InputFile Document { get; }

    /// <inheritdoc cref="Abstractions.Documentation.Thumbnail"/>
    [DataMember(EmitDefaultValue = false)]
    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Document caption (may also be used when resending documents by file_id), 0-1024 characters
    /// after entities parsing
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
    /// Disables automatic server-side content type detection for files uploaded using multipart/form-data
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableContentTypeDetection { get; set; }

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
    /// Initializes a new request with chatId and document
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="document">
    /// File to send. Pass a <see cref="InputFileId"/> as string to send a file that
    /// exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram
    /// to get a file from the Internet, or upload a new one using multipart/form-data
    /// </param>
    public SendDocumentRequest(ChatId chatId, InputFile document)
        : base("sendDocument")
    {
        ChatId = chatId;
        Document = document;
    }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        Document is InputFileStream || Thumbnail is InputFileStream
            ? GenerateMultipartFormDataContent("document", "thumbnail")
                .AddContentIfInputFile(media: Document, name: "document")
                .AddContentIfInputFile(media: Thumbnail, name: "thumbnail")
            : base.ToHttpContent();
}

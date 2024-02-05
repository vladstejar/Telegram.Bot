using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a file. By default, this file will be sent by the user with an optional caption.
/// Alternatively, you can use <see cref="InlineQueryResultDocument.InputMessageContent"/> to send
/// a message with the specified content instead of the file. Currently, only .PDF and .ZIP files
/// can be sent using this method.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultDocument : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be document
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Document;

    /// <summary>
    /// Title for the result
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; }

    /// <inheritdoc cref="Documentation.Caption" />
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <summary>
    /// A valid URL for the file
    /// </summary>
    [DataMember(IsRequired = true)]
    public string DocumentUrl { get; }

    /// <summary>
    /// Mime type of the content of the file, either “application/pdf” or “application/zip”
    /// </summary>
    [DataMember(IsRequired = true)]
    public string MimeType { get; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Description { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    [DataMember(EmitDefaultValue = false)]
    public InputMessageContent? InputMessageContent { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailUrl" />
    [DataMember(EmitDefaultValue = false)]
    public string? ThumbnailUrl { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailWidth" />
    [DataMember(EmitDefaultValue = false)]
    public int? ThumbnailWidth { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailHeight" />
    [DataMember(EmitDefaultValue = false)]
    public int? ThumbnailHeight { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    /// <param name="id">Unique identifier of this result</param>
    /// <param name="documentUrl">A valid URL for the file</param>
    /// <param name="title">Title of the result</param>
    /// <param name="mimeType">
    /// Mime type of the content of the file, either “application/pdf” or “application/zip”
    /// </param>
    public InlineQueryResultDocument(string id, string documentUrl, string title, string mimeType)
        : base(id)
    {
        DocumentUrl = documentUrl;
        Title = title;
        MimeType = mimeType;
    }
}

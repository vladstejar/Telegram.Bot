using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to a photo stored on the Telegram servers. By default, this photo will be sent
/// by the user with an optional caption. Alternatively, you can use
/// <see cref="InlineQueryResultCachedPhoto.InputMessageContent"/> to send a message with the
/// specified content instead of the photo.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultCachedPhoto : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be photo
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Photo;

    /// <summary>
    /// A valid file identifier of the photo
    /// </summary>
    [DataMember(IsRequired = true)]
    public string PhotoFileId { get; }

    /// <summary>
    /// Optional. Title for the result
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Title { get; set; }

    /// <summary>
    /// Optional. Short description of the result
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Description { get; set; }

    /// <inheritdoc cref="Documentation.Caption" />
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Documentation.ParseMode" />
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Documentation.CaptionEntities" />
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? CaptionEntities { get; set; }

    /// <inheritdoc cref="Documentation.InputMessageContent" />
    [DataMember(EmitDefaultValue = false)]
    public InputMessageContent? InputMessageContent { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    /// <param name="id">Unique identifier of this result</param>
    /// <param name="photoFileId">A valid file identifier of the photo</param>
    public InlineQueryResultCachedPhoto(string id, string photoFileId)
        : base(id)
    {
        PhotoFileId = photoFileId;
    }
}

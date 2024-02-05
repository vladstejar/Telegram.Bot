using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get information about custom emoji stickers by their identifiers.
/// Returns an Array of <see cref="Sticker"/> objects.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class GetCustomEmojiStickersRequest : RequestBase<Sticker[]>
{
    /// <summary>
    /// List of custom emoji identifiers. At most 200 custom emoji identifiers can be specified.
    /// </summary>
    [DataMember(IsRequired = true)]
    public IEnumerable<string> CustomEmojiIds { get; }

    /// <summary>
    /// Initializes a new request with name
    /// </summary>
    /// <param name="customEmojiIds">List of custom emoji identifiers. At most 200 custom emoji
    /// identifiers can be specified.</param>
    public GetCustomEmojiStickersRequest(IEnumerable<string> customEmojiIds)
        : base("getCustomEmojiStickers")
    {
        CustomEmojiIds = customEmojiIds;
    }
}

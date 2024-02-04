// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get custom emoji stickers, which can be used as a forum topic icon by any user.
/// Requires no parameters.
/// Returns an Array of <see cref="Sticker"/> objects.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class GetForumTopicIconStickersRequest : RequestBase<Sticker[]>
{
    /// <summary>
    /// Initializes a new request
    /// </summary>
    public GetForumTopicIconStickersRequest() : base("getForumTopicIconStickers")
    { }
}

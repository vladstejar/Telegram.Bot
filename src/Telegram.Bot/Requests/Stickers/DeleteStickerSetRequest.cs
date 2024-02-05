namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to delete a sticker set that was created by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class DeleteStickerSetRequest : RequestBase<bool>
{
    //
    /// <summary>
    /// Sticker set name
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Name { get; }

    /// <summary>
    /// Initializes a new request with name
    /// </summary>
    /// <param name="name">
    /// Sticker set name
    /// </param>
    public DeleteStickerSetRequest(string name)
        : base("deleteStickerSet")
    {
        Name = name;
    }
}

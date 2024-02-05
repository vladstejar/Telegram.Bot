namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the mask position of a mask sticker.
/// The sticker must belong to a sticker set that was created by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SetStickerMaskPositionRequest : RequestBase<bool>
{
    //
    /// <summary>
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </summary>
    [DataMember(IsRequired = true)]
    public InputFileId Sticker { get; }

    /// <summary>
    /// A JSON-serialized object with the position where the mask should be placed on faces.
    /// <see cref="Nullable">Omit</see> the parameter to remove the mask position.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public MaskPosition? MaskPosition { get; set; }

    /// <summary>
    /// Initializes a new request with sticker
    /// </summary>
    /// <param name="sticker">
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </param>
    public SetStickerMaskPositionRequest(InputFileId sticker)
        : base("setStickerMaskPosition")
    {
        Sticker = sticker;
    }
}

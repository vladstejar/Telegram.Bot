namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the mask position of a mask sticker.
/// The sticker must belong to a sticker set that was created by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="sticker">
/// <see cref="InputFileId">File identifier</see> of the sticker
/// </param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetStickerMaskPositionRequest(InputFileId sticker) : RequestBase<bool>("setStickerMaskPosition")
{
    //
    /// <summary>
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public InputFileId Sticker { get; } = sticker;

    /// <summary>
    /// A JSON-serialized object with the position where the mask should be placed on faces.
    /// <see cref="Nullable">Omit</see> the parameter to remove the mask position.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MaskPosition? MaskPosition { get; set; }
}

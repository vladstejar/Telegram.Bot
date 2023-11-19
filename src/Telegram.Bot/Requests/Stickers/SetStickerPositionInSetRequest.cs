// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to move a sticker in a set created by the bot to a specific position.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="sticker">
/// <see cref="InputFileId">File identifier</see> of the sticker
/// </param>
/// <param name="position">New sticker position in the set, zero-based</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetStickerPositionInSetRequest(InputFileId sticker, int position)
    : RequestBase<bool>("setStickerPositionInSet")
{
    /// <summary>
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public InputFileId Sticker { get; } = sticker;

    /// <summary>
    /// New sticker position in the set, zero-based
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int Position { get; } = position;
}

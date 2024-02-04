namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object represents one shipping option.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class ShippingOption
{
    /// <summary>
    /// Shipping option identifier
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Id { get; set; } = default!;

    /// <summary>
    /// Option title
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Title { get; set; } = default!;

    /// <summary>
    /// List of price portions
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public LabeledPrice[] Prices { get; set; } = default!;
}

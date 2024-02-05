namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object represents one shipping option.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ShippingOption
{
    /// <summary>
    /// Shipping option identifier
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Id { get; set; } = default!;

    /// <summary>
    /// Option title
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; set; } = default!;

    /// <summary>
    /// List of price portions
    /// </summary>
    [DataMember(IsRequired = true)]
    public LabeledPrice[] Prices { get; set; } = default!;
}

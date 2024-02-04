namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object represents a portion of the price for goods or services.
/// </summary>
/// <a href="https://core.telegram.org/bots/api#labeledprice"/>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class LabeledPrice
{
    /// <summary>
    /// Portion label
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Label { get; set; }

    /// <summary>
    /// Price of the product in the <i>smallest units</i> of the
    /// <a href="https://core.telegram.org/bots/payments#supported-currencies">currency</a>
    /// (integer, <b>not</b> float/double).
    /// <para>
    /// For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the <i>exp</i> parameter in
    /// <a href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number
    /// of digits past the decimal point for each currency (2 for the majority of currencies).
    /// </para>
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int Amount { get; set; }

    /// <summary>
    /// Initializes an instance of <see cref="LabeledPrice"/>
    /// </summary>
    /// <param name="label">Portion label</param>
    /// <param name="amount">Price of the product</param>
    #if !NET7_0_OR_GREATER
    [JsonConstructor]
    #endif
    public LabeledPrice(string label, int amount)
    {
        Label = label;
        Amount = amount;
    }
}

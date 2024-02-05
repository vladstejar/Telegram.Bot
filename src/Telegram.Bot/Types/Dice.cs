using static Telegram.Bot.Types.Enums.Emoji;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a dice with random value
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class Dice
{
    /// <summary>
    /// Emoji on which the dice throw animation is based
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Emoji { get; set; } = default!;
    /// <summary>
    /// Value of the dice, 1-6 for <see cref="Telegram.Bot.Types.Enums.Emoji.Dice" /> (“🎲”),
    /// <see cref="Darts" /> (“🎯”) and <see cref="Bowling"/> ("🎳"), 1-5 for <see cref="Basketball" /> (“🏀”) and
    /// <see cref="Football" />("⚽"), and values 1-64 for <see cref="SlotMachine" /> ("🎰"). Defaults to
    /// <see cref="Telegram.Bot.Types.Enums.Emoji.Dice" /> (“🎲”)
    /// </summary>
    [DataMember(IsRequired = true)]
    public int Value { get; set; }
}

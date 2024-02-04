namespace Telegram.Bot.Types;

/// <summary>
/// This object represents one row of the high scores table for a game.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class GameHighScore
{
    /// <summary>
    /// Position in high score table for the game.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int Position { get; set; }

    /// <summary>
    /// User
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public User User { get; set; } = default!;

    /// <summary>
    /// Score
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public int Score { get; set; }
}

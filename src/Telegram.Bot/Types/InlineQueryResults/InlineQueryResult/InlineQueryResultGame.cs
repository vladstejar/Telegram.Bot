

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a <see cref="Game"/>.
/// </summary>
/// <param name="id">Unique identifier of this result</param>
/// <param name="gameShortName">Short name of the game</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultGame(string id, string gameShortName) : InlineQueryResult(id)
{
    /// <summary>
    /// Type of the result, must be game
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public override InlineQueryResultType Type => InlineQueryResultType.Game;

    /// <summary>
    /// Short name of the game
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string GameShortName { get; } = gameShortName;
}

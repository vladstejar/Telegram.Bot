using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get data for high score tables. Will return the score of the specified user
/// and several of their neighbors in a game. On success, returns an Array of
/// <see cref="GameHighScore"/> objects.
/// </summary>
/// <remarks>
/// This method will currently return scores for the target user, plus two of their closest neighbors
/// on each side. Will also return the top three users if the user and his neighbors are not among them.
/// Please note that this behavior is subject to change.
/// </remarks>
/// <param name="userId">User identifier</param>
/// <param name="inlineMessageId">Identifier of the inline message</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetInlineGameHighScoresRequest(long userId, string inlineMessageId)
    : RequestBase<GameHighScore[]>("getGameHighScores"),
      IUserTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public long UserId { get; } = userId;

    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    [JsonProperty(Required = Required.Always)]
    public string InlineMessageId { get; } = inlineMessageId;
}

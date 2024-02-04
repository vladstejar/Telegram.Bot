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
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class GetInlineGameHighScoresRequest : RequestBase<GameHighScore[]>, IUserTargetable
{
    /// <inheritdoc />
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public long UserId { get; }

    /// <inheritdoc cref="Abstractions.Documentation.InlineMessageId"/>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string InlineMessageId { get; }

    /// <summary>
    /// Initializes a new request with userId and inlineMessageId
    /// </summary>
    /// <param name="userId">User identifier</param>
    /// <param name="inlineMessageId">Identifier of the inline message</param>
    public GetInlineGameHighScoresRequest(long userId, string inlineMessageId)
        : base("getGameHighScores")
    {
        UserId = userId;
        InlineMessageId = inlineMessageId;
    }
}

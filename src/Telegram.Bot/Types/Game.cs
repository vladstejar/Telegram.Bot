namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a game. Use BotFather to create and edit games, their short names will act as unique
/// identifiers.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class Game
{
    /// <summary>
    /// Title of the game.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Title { get; set; } = default!;

    /// <summary>
    /// Description of the game.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Description { get; set; } = default!;

    /// <summary>
    /// Photo that will be displayed in the game message in chats.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public PhotoSize[] Photo { get; set; } = default!;

    /// <summary>
    /// Optional. Brief description of the game or high scores included in the game message. Can be automatically
    /// edited to include current high scores for the game when the bot calls
    /// <see cref="Requests.SetGameScoreRequest"/>, or manually edited using
    /// <see cref="Requests.EditMessageTextRequest"/>. 0-4096 characters.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? Text { get; set; }

    /// <summary>
    /// Optional. Special entities that appear in text, such as usernames, URLs, bot commands, etc.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public MessageEntity[]? TextEntities { get; set; }

    /// <summary>
    /// Optional. Animation that will be displayed in the game message in chats. Upload via
    /// <a href="https://t.me/botfather">@BotFather</a>
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public Animation? Animation { get; set; }
}

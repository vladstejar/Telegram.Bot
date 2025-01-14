﻿namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a game. Use BotFather to create and edit games, their short names will act as unique identifiers.
/// </summary>
public partial class Game
{
    /// <summary>
    /// Title of the game
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Title { get; set; } = default!;

    /// <summary>
    /// Description of the game
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Description { get; set; } = default!;

    /// <summary>
    /// Photo that will be displayed in the game message in chats.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public PhotoSize[] Photo { get; set; } = default!;

    /// <summary>
    /// <em>Optional</em>. Brief description of the game or high scores included in the game message. Can be automatically edited to include current high scores for the game when the bot calls <see cref="TelegramBotClientExtensions.SetGameScoreAsync">SetGameScore</see>, or manually edited using <see cref="TelegramBotClientExtensions.EditMessageTextAsync">EditMessageText</see>. 0-4096 characters.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }

    /// <summary>
    /// <em>Optional</em>. Special entities that appear in <see cref="Text">Text</see>, such as usernames, URLs, bot commands, etc.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MessageEntity[]? TextEntities { get; set; }

    /// <summary>
    /// <em>Optional</em>. Animation that will be displayed in the game message in chats. Upload via <a href="https://t.me/botfather">@BotFather</a>
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Animation? Animation { get; set; }
}

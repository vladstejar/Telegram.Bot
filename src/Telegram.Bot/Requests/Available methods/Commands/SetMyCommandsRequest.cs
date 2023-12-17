using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the list of the bot’s commands. See
/// <a href="https://core.telegram.org/bots#commands"/> for more details about bot commands.
/// Returns <see langword="true"/> on success
/// </summary>
/// <param name="commands">A list of bot commands to be set</param>
public class SetMyCommandsRequest(IEnumerable<BotCommand> commands) : RequestBase<bool>("setMyCommands")
{
    /// <summary>
    /// A list of bot commands to be set as the list of the bot’s commands.
    /// At most 100 commands can be specified.
    /// </summary>
    public IEnumerable<BotCommand> Commands { get; } = commands;

    /// <summary>
    /// An object, describing scope of users for which the commands are relevant.
    /// Defaults to <see cref="BotCommandScopeDefault"/>.
    /// </summary>
    public BotCommandScope? Scope { get; set; }

    /// <summary>
    /// A two-letter ISO 639-1 language code. If empty, commands will be applied to all users
    /// from the given <see cref="Scope"/>, for whose language there are no dedicated commands
    /// </summary>
    public string? LanguageCode { get; set; }
}

using JetBrains.Annotations;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a file ready to be downloaded. The file can be downloaded via
/// <see cref="TelegramBotClientExtensions.GetFileAsync"/>.
/// It is guaranteed that the link will be valid for at least 1 hour. When the link expires, a new one can be
/// requested by calling <see cref="TelegramBotClientExtensions.GetFileAsync"/>.
/// </summary>
[PublicAPI]
public class File : FileBase
{
    /// <summary>
    /// Optional. File path. Use <see cref="TelegramBotClientExtensions.GetFileAsync"/> to get the file.
    /// </summary>
    public string? FilePath { get; set; }
}

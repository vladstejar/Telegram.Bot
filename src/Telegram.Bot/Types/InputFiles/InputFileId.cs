using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a file that is already stored somewhere on the Telegram servers
/// </summary>
/// <param name="id">A file identifier</param>
public class InputFileId(string id) : InputFile
{
    /// <inheritdoc/>
    public override FileType FileType => FileType.Id;

    /// <summary>
    /// A file identifier
    /// </summary>
    public string Id { get; } = id;

    // Needed for STJ to work
    [JsonConstructor]
    private InputFileId(string id, FileType fileType) : this(id)
    { }
}

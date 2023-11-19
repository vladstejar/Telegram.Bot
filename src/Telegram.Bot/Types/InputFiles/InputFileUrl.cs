using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// This object represents an HTTP URL for the file to be sent
/// </summary>
/// <param name="uri">HTTP URL for the file to be sent</param>
public class InputFileUrl(Uri uri) : InputFile
{
    /// <inheritdoc/>
    public override FileType FileType => FileType.Url;

    /// <summary>
    /// HTTP URL for the file to be sent
    /// </summary>
    public Uri Url { get; } = uri;

    /// <summary>
    /// This object represents an HTTP URL for the file to be sent
    /// </summary>
    /// <param name="url">HTTP URL for the file to be sent</param>
    public InputFileUrl(string url)
        : this(new Uri(url))
    {}
}

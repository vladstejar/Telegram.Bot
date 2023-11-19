using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Telegram.Bot.Polling;

/// <summary>
/// A very simple <see cref="IUpdateHandler"/> implementation
/// </summary>
/// <remarks>
/// Constructs a new <see cref="DefaultUpdateHandler"/> with the specified callback functions
/// </remarks>
/// <param name="updateHandler">The function to invoke when an update is received</param>
/// <param name="pollingErrorHandler">The function to invoke when an error occurs</param>
[PublicAPI]
public class DefaultUpdateHandler(AsyncUpdateHandler updateHandler, AsyncPollingErrorHandler pollingErrorHandler)
    : IUpdateHandler
{
    readonly AsyncUpdateHandler _updateHandler
        = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));

    readonly AsyncPollingErrorHandler _pollingErrorHandler
        = pollingErrorHandler ?? throw new ArgumentNullException(nameof(pollingErrorHandler));

    /// <inheritdoc />
    public async Task HandleUpdateAsync(
        ITelegramBotClient botClient,
        Update update,
        CancellationToken cancellationToken
    ) =>
        await _updateHandler(botClient, update, cancellationToken).ConfigureAwait(false);

    /// <inheritdoc />
    public async Task HandlePollingErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        CancellationToken cancellationToken
    ) =>
        await _pollingErrorHandler(botClient, exception, cancellationToken).ConfigureAwait(false);
}

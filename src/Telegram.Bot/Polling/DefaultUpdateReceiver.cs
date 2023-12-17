using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Telegram.Bot.Requests;

namespace Telegram.Bot.Polling;

/// <summary>
/// A simple <see cref="IUpdateReceiver"/>> implementation that requests new updates and handles them sequentially
/// </summary>
/// <remarks>
/// Constructs a new <see cref="DefaultUpdateReceiver"/> with the specified <see cref="ITelegramBotClient"/>>
/// instance and optional <see cref="ReceiverOptions"/>
/// </remarks>
/// <param name="botClient">The <see cref="ITelegramBotClient"/> used for making GetUpdates calls</param>
/// <param name="receiverOptions">Options used to configure getUpdates requests</param>
[PublicAPI]
public class DefaultUpdateReceiver(
    ITelegramBotClient botClient,
    ReceiverOptions? receiverOptions = default) : IUpdateReceiver
{
    static readonly Update[] EmptyUpdates = [];

    readonly ITelegramBotClient _botClient = botClient ?? throw new ArgumentNullException(nameof(botClient));

    /// <inheritdoc />
    public async Task ReceiveAsync(
        IUpdateHandler updateHandler,
        CancellationToken cancellationToken = default)
    {
        if (updateHandler is null) { throw new ArgumentNullException(nameof(updateHandler)); }

        var allowedUpdates = receiverOptions?.AllowedUpdates;
        var limit = receiverOptions?.Limit ?? default;
        var messageOffset = receiverOptions?.Offset ?? 0;
        Update[] emptyUpdates = EmptyUpdates;

        if (receiverOptions?.ThrowPendingUpdates is true)
        {
            try
            {
                messageOffset = await _botClient.ThrowOutPendingUpdatesAsync(
                    cancellationToken: cancellationToken
                ).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // ignored
            }
        }

        while (!cancellationToken.IsCancellationRequested)
        {
            var timeout = (int) _botClient.Timeout.TotalSeconds;
            var updates = emptyUpdates;
            try
            {
                var request = new GetUpdatesRequest
                {
                    Limit = limit,
                    Offset = messageOffset,
                    Timeout = timeout,
                    AllowedUpdates = allowedUpdates,
                };
                updates = await _botClient.MakeRequestAsync(
                    request: request,
                    cancellationToken:
                    cancellationToken
                ).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Ignore
            }
#pragma warning disable CA1031
            catch (Exception exception)
#pragma warning restore CA1031
            {
                try
                {
                    await updateHandler.HandlePollingErrorAsync(
                        botClient: _botClient,
                        exception: exception,
                        cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    // ignored
                }
            }

            foreach (var update in updates)
            {
                try
                {
                    await updateHandler.HandleUpdateAsync(
                        botClient: _botClient,
                        update: update,
                        cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                    messageOffset = update.Id + 1;
                }
                catch (OperationCanceledException)
                {
                    // ignored
                }
            }
        }
    }
}

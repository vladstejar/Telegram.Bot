#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Telegram.Bot.Requests;
using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Polling;

/// <summary>
/// Supports asynchronous iteration over <see cref="Update"/>s
/// </summary>
/// <param name="botClient">The <see cref="ITelegramBotClient"/> used for making GetUpdates calls</param>
/// <param name="receiverOptions"></param>
/// <param name="pollingErrorHandler">
/// The function used to handle <see cref="Exception"/>s thrown by ReceiveUpdates
/// </param>
[PublicAPI]
public class BlockingUpdateReceiver(
    ITelegramBotClient botClient,
    ReceiverOptions? receiverOptions = default,
    Func<Exception, CancellationToken, Task>? pollingErrorHandler = default)
        : IAsyncEnumerable<Update>
{
    int _inProcess;

    /// <summary>
    /// Gets the <see cref="IAsyncEnumerator{Update}"/>. This method may only be called once.
    /// </summary>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> with which you can stop receiving
    /// </param>
    public IAsyncEnumerator<Update> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        if (Interlocked.CompareExchange(ref _inProcess, 1, 0) is 1)
        {
            throw new InvalidOperationException($"{nameof(GetAsyncEnumerator)} may only be called once");
        }

        return new Enumerator(botClient, this, cancellationToken, receiverOptions, pollingErrorHandler);
    }

    class Enumerator(
        ITelegramBotClient botClient,
        BlockingUpdateReceiver receiver,
        CancellationToken cancellationToken,
        ReceiverOptions? receiverOptions = default,
        Func<Exception, CancellationToken, Task>? pollingErrorHandler = default) : IAsyncEnumerator<Update>
    {
        readonly CancellationTokenSource _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, default);
        readonly UpdateType[]? _allowedUpdates = receiverOptions?.AllowedUpdates;
        readonly int? _limit = receiverOptions?.Limit ?? default;

        Update[] _updateArray = [];
        int _updateIndex;
        int _messageOffset = receiverOptions?.Offset ?? 0;
        bool _updatesThrown;

        public ValueTask<bool> MoveNextAsync()
        {
            _cts.Token.ThrowIfCancellationRequested();

            _updateIndex += 1;

            return _updateIndex < _updateArray.Length
                ? new(true)
                : new(ReceiveUpdatesAsync());
        }

        async Task<bool> ReceiveUpdatesAsync()
        {
            var shouldThrowPendingUpdates = (
                _updatesThrown,
                receiverOptions?.ThrowPendingUpdates ?? false
            );

            if (shouldThrowPendingUpdates is (false, true))
            {
                try
                {
                    _messageOffset = await botClient
                        .ThrowOutPendingUpdatesAsync(_cts.Token)
                        .ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    // ignored
                }
                finally
                {
                    _updatesThrown = true;
                }
            }

            _updateArray = [];
            _updateIndex = 0;

            while (_updateArray.Length is 0)
            {
                try
                {
                    _updateArray = await botClient
                        .MakeRequestAsync(
                            new GetUpdatesRequest
                            {
                                Offset = _messageOffset,
                                Timeout = (int) botClient.Timeout.TotalSeconds,
                                Limit = _limit,
                                AllowedUpdates = _allowedUpdates,
                            },
                            cancellationToken: _cts.Token
                        )
                        .ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception ex) when (pollingErrorHandler is not null)
                {
                    await pollingErrorHandler(ex, _cts.Token).ConfigureAwait(false);
                }
            }

            _messageOffset = _updateArray[^1].Id + 1;
            return true;
        }

        public Update Current => _updateArray[_updateIndex];

        public ValueTask DisposeAsync()
        {
            _cts.Cancel();
            _cts.Dispose();
            return new();
        }
    }
}
#endif

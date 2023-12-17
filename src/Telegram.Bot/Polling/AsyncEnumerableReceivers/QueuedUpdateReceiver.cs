#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Telegram.Bot.Requests;
using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Polling;

/// <summary>
/// Supports asynchronous iteration over <see cref="Update"/>s.
/// <para>Updates are received on a different thread and enqueued.</para>
/// </summary>
/// <param name="botClient">The <see cref="ITelegramBotClient"/> used for making GetUpdates calls</param>
/// <param name="receiverOptions"></param>
/// <param name="pollingErrorHandler">
/// The function used to handle <see cref="Exception"/>s thrown by GetUpdates requests
/// </param>
[PublicAPI]
#pragma warning disable CA1001
public class QueuedUpdateReceiver(
    ITelegramBotClient botClient,
    ReceiverOptions? receiverOptions = default,
    Func<Exception, CancellationToken, Task>? pollingErrorHandler = default)
        : IAsyncEnumerable<Update>
#pragma warning restore CA1001
{
    int _inProcess;
    Enumerator? _enumerator;

    /// <summary>
    /// Indicates how many <see cref="Update"/>s are ready to be returned the enumerator
    /// </summary>
    public int PendingUpdates => _enumerator?.PendingUpdates ?? 0;

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
            throw new InvalidOperationException(nameof(GetAsyncEnumerator) + " may only be called once");
        }

        _enumerator = new(botClient, cancellationToken, receiverOptions, pollingErrorHandler);

        return _enumerator;
    }

    class Enumerator(
        ITelegramBotClient botClient,
        CancellationToken cancellationToken,
        ReceiverOptions? receiverOptions = default,
        Func<Exception, CancellationToken, Task>? pollingErrorHandler = default)
            : IAsyncEnumerator<Update>
    {
        readonly CancellationTokenSource _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, default);
        readonly UpdateType[]? _allowedUpdates = receiverOptions?.AllowedUpdates;
        readonly int? _limit = receiverOptions?.Limit ?? default;
        readonly Channel<Update> _channel = Channel.CreateUnbounded<Update>(
            new()
            {
                SingleReader = true,
                SingleWriter = true,
            });

        Task? _worker;
        Update? _current;
        Exception? _uncaughtException;

        int _pendingUpdates;
        int _messageOffset = receiverOptions?.Offset ?? 0;

        public int PendingUpdates => _pendingUpdates;

        public ValueTask<bool> MoveNextAsync()
        {
            _worker ??= Task.Run(ReceiveUpdatesAsync);

            if (_uncaughtException is not null) { throw _uncaughtException; }

            _cts.Token.ThrowIfCancellationRequested();

            if (_channel.Reader.TryRead(out _current))
            {
                Interlocked.Decrement(ref _pendingUpdates);
                return new(true);
            }

            return new(ReadAsync());
        }

        async Task<bool> ReadAsync()
        {
            _current = await _channel.Reader.ReadAsync(_cts.Token).ConfigureAwait(false);
            Interlocked.Decrement(ref _pendingUpdates);
            return true;
        }

        async Task ReceiveUpdatesAsync()
        {
            if (receiverOptions?.ThrowPendingUpdates is true)
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
            }

            while (!_cts.IsCancellationRequested)
            {
                try
                {
                    Update[] updates = await botClient
                        .MakeRequestAsync(
                            new GetUpdatesRequest
                            {
                                Offset = _messageOffset,
                                Timeout = (int)botClient.Timeout.TotalSeconds,
                                AllowedUpdates = _allowedUpdates,
                                Limit = _limit,
                            },
                            cancellationToken: _cts.Token
                        )
                        .ConfigureAwait(false);

                    if (updates.Length > 0)
                    {
                        _messageOffset = updates[^1].Id + 1;

                        Interlocked.Add(ref _pendingUpdates, updates.Length);

                        ChannelWriter<Update> writer = _channel.Writer;
                        foreach (Update update in updates)
                        {
                            // ReSharper disable once RedundantAssignment
                            var success = writer.TryWrite(update);
                            Debug.Assert(success, "TryWrite should succeed as we are using an unbounded channel");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ignore
                }
#pragma warning disable CA1031
                catch (Exception ex)
#pragma warning restore CA1031
                {
                    Debug.Assert(_uncaughtException is null);

                    // If there is no errorHandler or the errorHandler throws, stop receiving
                    if (pollingErrorHandler is null)
                    {
                        _uncaughtException = ex;
                        _cts.Cancel();
                    }
                    else
                    {
                        try
                        {
                            await pollingErrorHandler(ex, _cts.Token).ConfigureAwait(false);
                        }
#pragma warning disable CA1031
                        catch (Exception errorHandlerException)
#pragma warning restore CA1031
                        {
                            _uncaughtException = new AggregateException(
                                message: "Exception was not caught by the errorHandler.",
                                ex,
                                errorHandlerException
                            );
                            _cts.Cancel();
                        }
                    }

                    if (_uncaughtException is not null)
                    {
#pragma warning disable CA2201
                        _uncaughtException = new(
                            message: "Exception was not caught by the errorHandler.",
                            innerException: _uncaughtException
                        );
#pragma warning restore CA2201
                    }
                }
            }
        }

        public Update Current => _current!; // _current being null indicates MoveNextAsync was never called

        public ValueTask DisposeAsync()
        {
            _cts.Cancel();
            _cts.Dispose();
            return new();
        }
    }
}
#endif

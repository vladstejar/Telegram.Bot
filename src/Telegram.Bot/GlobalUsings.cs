// Global using directives

global using System;
global using System.Text.Json;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using Telegram.Bot.Types;

global using AsyncUpdateHandler = System.Func<Telegram.Bot.ITelegramBotClient, Telegram.Bot.Types.Update, System.Threading.CancellationToken, System.Threading.Tasks.Task>;
global using AsyncPollingErrorHandler = System.Func<Telegram.Bot.ITelegramBotClient, System.Exception, System.Threading.CancellationToken, System.Threading.Tasks.Task>;

global using UpdateHandler = System.Action<Telegram.Bot.ITelegramBotClient, Telegram.Bot.Types.Update, System.Threading.CancellationToken>;
global using PollingErrorHandler  = System.Action<Telegram.Bot.ITelegramBotClient, System.Exception, System.Threading.CancellationToken>;

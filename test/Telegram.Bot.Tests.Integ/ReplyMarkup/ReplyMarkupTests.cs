using System.Threading.Tasks;
using Telegram.Bot.Tests.Integ.Framework;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Xunit;

namespace Telegram.Bot.Tests.Integ.ReplyMarkup;

[Collection(Constants.TestCollections.ReplyMarkup)]
[TestCaseOrderer(Constants.TestCaseOrderer, Constants.AssemblyName)]
public class ReplyMarkupTests(TestsFixture testsFixture)
{
    ITelegramBotClient BotClient => testsFixture.BotClient;

    [OrderedFact("Should send a message with force reply markup")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendMessage)]
    public async Task Should_Force_Reply()
    {
        await BotClient.SendTextMessageAsync(
            chatId: testsFixture.SupergroupChat,
            text: "Message with force_reply",
            replyMarkup: new ForceReplyMarkup()
        );
    }

    [OrderedFact("Should send a message multi-row keyboard reply markup")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendMessage)]
    public async Task Should_Send_MultiRow_Keyboard()
    {
        KeyboardButton[][] keyboard =
        [
            ["Top-Left",     "Top"  , "Top-Right"],
            ["Left",        "Center", "Right"],
            ["Bottom-Left", "Bottom", "Bottom-Right"],
        ];

        ReplyKeyboardMarkup replyMarkup = new(keyboard: keyboard)
        {
            ResizeKeyboard = true,
        };

        await BotClient.SendTextMessageAsync(
            chatId: testsFixture.SupergroupChat,
            text: "Message with 3x3 keyboard",
            replyMarkup: replyMarkup
        );
    }

    [OrderedFact("Should remove reply keyboard")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendMessage)]
    public async Task Should_Remove_Reply_Keyboard()
    {
        await BotClient.SendTextMessageAsync(
            chatId: testsFixture.SupergroupChat,
            text: "Message to remove keyboard",
            replyMarkup: new ReplyKeyboardRemove()
        );
    }

    [OrderedFact("Should send a message with multiple inline keyboard buttons markup")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendMessage)]
    public async Task Should_Send_Inline_Keyboard()
    {
        InlineKeyboardButton[][] keyboard =
        [
            [
                InlineKeyboardButton.WithUrl(
                    text: "Link to Repository",
                    url: "https://github.com/TelegramBots/Telegram.Bot"),
            ],
            [
                InlineKeyboardButton.WithCallbackData(textAndCallbackData: "callback_data1"),
                InlineKeyboardButton.WithCallbackData(text: "callback_data: a2", callbackData: "data"),
            ],
            [InlineKeyboardButton.WithSwitchInlineQuery(text: "switch_inline_query"),],
            [InlineKeyboardButton.WithSwitchInlineQueryCurrentChat(text: "switch_inline_query_current_chat"),],
        ];

        InlineKeyboardMarkup replyMarkup = new(keyboard);

        Message sentMessage = await BotClient.SendTextMessageAsync(
            chatId: testsFixture.SupergroupChat,
            text: "Message with inline keyboard markup",
            replyMarkup: replyMarkup
        );

        Asserts.JsonEquals(replyMarkup, sentMessage.ReplyMarkup);
    }
}

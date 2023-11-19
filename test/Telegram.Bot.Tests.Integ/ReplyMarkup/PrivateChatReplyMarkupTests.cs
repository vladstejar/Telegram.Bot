using System.Threading.Tasks;
using Telegram.Bot.Tests.Integ.Framework;
using Telegram.Bot.Tests.Integ.Framework.Fixtures;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Xunit;

namespace Telegram.Bot.Tests.Integ.ReplyMarkup;

[Collection(Constants.TestCollections.PrivateChatReplyMarkup)]
[Trait(Constants.CategoryTraitName, Constants.InteractiveCategoryValue)]
[TestCaseOrderer(Constants.TestCaseOrderer, Constants.AssemblyName)]
public class PrivateChatReplyMarkupTests(TestsFixture testsFixture, PrivateChatReplyMarkupTests.Fixture fixture)
    : IClassFixture<PrivateChatReplyMarkupTests.Fixture>
{
    ITelegramBotClient BotClient => testsFixture.BotClient;

    [OrderedFact("Should get contact info from keyboard reply markup")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendMessage)]
    public async Task Should_Receive_Contact_Info()
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new([KeyboardButton.WithRequestContact("Share Contact"),])
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true,
        };

        await BotClient.SendTextMessageAsync(
            chatId: fixture.PrivateChat,
            text: "Share your contact info using the keyboard reply markup provided.",
            replyMarkup: replyKeyboardMarkup
        );

        Message contactMessage = await GetMessageFromChat(MessageType.Contact);

        Assert.NotNull(contactMessage.Contact);
        Assert.NotEmpty(contactMessage.Contact.FirstName);
        Assert.NotEmpty(contactMessage.Contact.PhoneNumber);
        Assert.Equal(fixture.PrivateChat.Id, contactMessage.Contact.UserId);

        await BotClient.SendTextMessageAsync(
            chatId: fixture.PrivateChat,
            text: "Got it. Removing reply keyboard markup...",
            replyMarkup: new ReplyKeyboardRemove()
        );
    }

    [OrderedFact("Should get location from keyboard reply markup")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendMessage)]
    public async Task Should_Receive_Location()
    {
        await BotClient.SendTextMessageAsync(
            chatId: fixture.PrivateChat,
            text: "Share your location using the keyboard reply markup",
            replyMarkup: new ReplyKeyboardMarkup(KeyboardButton.WithRequestLocation("Share Location"))
        );

        Message locationMessage = await GetMessageFromChat(MessageType.Location);

        Assert.NotNull(locationMessage.Location);

        await BotClient.SendTextMessageAsync(
            chatId: fixture.PrivateChat,
            text: "Got it. Removing reply keyboard markup...",
            replyMarkup: new ReplyKeyboardRemove()
        );
    }

    async Task<Message> GetMessageFromChat(MessageType messageType) =>
        (await testsFixture.UpdateReceiver.GetUpdateAsync(
            predicate: u => u.Message!.Type == messageType &&
                            u.Message.Chat.Id == fixture.PrivateChat.Id,
            updateTypes: UpdateType.Message
        )).Message;

    public class Fixture(TestsFixture testsFixture)
        : PrivateChatFixture(testsFixture, Constants.TestCollections.ReplyMarkup);
}

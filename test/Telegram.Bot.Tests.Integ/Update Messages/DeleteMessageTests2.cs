using System.Threading.Tasks;
using Telegram.Bot.Tests.Integ.Framework;
using Telegram.Bot.Types;
using Xunit;

namespace Telegram.Bot.Tests.Integ.Update_Messages;

[Collection(Constants.TestCollections.DeleteMessage2)]
[TestCaseOrderer(Constants.TestCaseOrderer, Constants.AssemblyName)]
public class DeleteMessageTests2(TestsFixture fixture)
{
    ITelegramBotClient BotClient => fixture.BotClient;

    [OrderedFact("Should delete message")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendMessage)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.DeleteMessage)]
    public async Task Should_Delete_Message()
    {
        Message message = await BotClient.SendTextMessageAsync(
            chatId: fixture.SupergroupChat.Id,
            text: "This message will be deleted shortly"
        );

        await Task.Delay(1_000);

        await BotClient.DeleteMessageAsync(
            chatId: message.Chat.Id,
            messageId: message.MessageId
        );
    }
}

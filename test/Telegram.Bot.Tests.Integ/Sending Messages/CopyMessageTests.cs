using System.Threading.Tasks;
using Telegram.Bot.Tests.Integ.Framework;
using Telegram.Bot.Types;
using Xunit;

namespace Telegram.Bot.Tests.Integ.Sending_Messages;

[Collection(Constants.TestCollections.SendCopyMessage)]
[TestCaseOrderer(Constants.TestCaseOrderer, Constants.AssemblyName)]
public class CopyMessageTests(TestsFixture testsFixture)
{
    ITelegramBotClient BotClient => testsFixture.BotClient;

    [OrderedFact("Should copy text message")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CopyMessage)]
    public async Task Should_Copy_Text_Message()
    {
        Message message = await BotClient.SendTextMessageAsync(
            chatId: testsFixture.SupergroupChat.Id,
            text: "hello"
        );

        MessageId copyMessageId = await BotClient.CopyMessageAsync(
            testsFixture.SupergroupChat.Id,
            testsFixture.SupergroupChat.Id,
            message.MessageId
        );

        Assert.NotEqual(0, copyMessageId.Id);
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Tests.Integ.Framework;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Integ.Stickers;

[Collection(Constants.TestCollections.Stickers)]
[Trait(Constants.CategoryTraitName, Constants.InteractiveCategoryValue)]
[TestCaseOrderer(Constants.TestCaseOrderer, Constants.AssemblyName)]
public class StickersTests(TestsFixture fixture, StickersTestsFixture classFixture)
    : IClassFixture<StickersTestsFixture>
{
    private ITelegramBotClient BotClient => fixture.BotClient;

    #region 1. Upload sticker files
    [OrderedFact("Shound upload static sticker file")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.UploadStickerFile)]
    public async Task Shound_Upload_Static_Sticker_File()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(Constants.PathToFile.Sticker.Regular.StaticFirst);

        File file = await BotClient.UploadStickerFileAsync(
            userId: classFixture.OwnerUserId,
            sticker: new InputFileStream(stream),
            StickerFormat.Static
        );

        Assert.NotEmpty(file.FileId);
        Assert.True(file.FileSize > 0);

        classFixture.TestUploadedStaticStickerFile = file;
    }

    [OrderedFact("Shound upload animated sticker file")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.UploadStickerFile)]
    public async Task Should_Upload_Animated_Sticker_File()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(Constants.PathToFile.Sticker.Regular.AnimatedFirst);

        File file = await BotClient.UploadStickerFileAsync(
            userId: classFixture.OwnerUserId,
            sticker: new InputFileStream(stream),
            StickerFormat.Animated
        );

        Assert.NotEmpty(file.FileId);
        Assert.True(file.FileSize > 0);

        classFixture.TestUploadedAnimatedStickerFile = file;
    }

    [OrderedFact("Should upload video sticker file")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.UploadStickerFile)]
    public async Task Should_Upload_Video_Sticker_File()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(Constants.PathToFile.Sticker.Regular.VideoFirst);

        File file = await BotClient.UploadStickerFileAsync(
            userId: classFixture.OwnerUserId,
            sticker: new InputFileStream(stream),
            StickerFormat.Video
        );

        Assert.NotEmpty(file.FileId);
        Assert.True(file.FileSize > 0);

        classFixture.TestUploadedVideoStickerFile = file;
    }
    #endregion

    #region 2. Create sticker sets
    [OrderedFact("Slound create new static sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Create_New_Static_Sticker_Set()
    {
        List<InputSticker> inputStickers = new(2);

        await using System.IO.Stream stream = System.IO.File.OpenRead(
            Constants.PathToFile.Sticker.Regular.StaticSecond
        );

        inputStickers.AddRange([
            new InputSticker(
                sticker: new InputFileId(classFixture.TestUploadedStaticStickerFile.FileId),
                emojiList: classFixture.FirstEmojis
            ),
            new InputSticker(
                sticker: new InputFileStream(stream, "Static2.webp"),
                emojiList: classFixture.SecondEmojis
            )
        ]);

        await BotClient.CreateNewStickerSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestStaticRegularStickerSetName,
            title: classFixture.TestStickerSetTitle,
            stickers: inputStickers,
            stickerFormat: StickerFormat.Static,
            stickerType: StickerType.Regular
        );

        await Task.Delay(1_000);

        classFixture.TestStaticRegularStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Assert.False(classFixture.TestStaticRegularStickerSet.IsAnimated);
        Assert.False(classFixture.TestStaticRegularStickerSet.IsVideo);
        Assert.True(classFixture.TestStaticRegularStickerSet.Stickers.Length == 2);
    }

    [OrderedFact("Should create new animated sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Create_New_Animated_Sticker_Set()
    {
        List<InputSticker> inputStickers = new(2);

        await using System.IO.Stream stream = System.IO.File.OpenRead(
            Constants.PathToFile.Sticker.Regular.AnimatedSecond
        );

        inputStickers.AddRange([
            new InputSticker(
                sticker: new InputFileId(classFixture.TestUploadedAnimatedStickerFile.FileId),
                emojiList: classFixture.FirstEmojis
            ),
            new InputSticker(
                sticker: new InputFileStream(stream, "Animated2.webp"),
                emojiList: classFixture.SecondEmojis
            )
        ]);

        await BotClient.CreateNewStickerSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestAnimatedRegularStickerSetName,
            title: classFixture.TestStickerSetTitle,
            stickers: inputStickers,
            stickerFormat: StickerFormat.Animated,
            stickerType: StickerType.Regular
        );

        await Task.Delay(1_000);

        classFixture.TestAnimatedRegularStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestAnimatedRegularStickerSetName
        );

        Assert.True(classFixture.TestAnimatedRegularStickerSet.IsAnimated);
        Assert.False(classFixture.TestAnimatedRegularStickerSet.IsVideo);
        Assert.True(classFixture.TestAnimatedRegularStickerSet.Stickers.Length == 2);
    }

    [OrderedFact("Should create new video sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Create_New_Video_Sticker_Set()
    {
        List<InputSticker> inputStickers = new(2);

        await using System.IO.Stream stream = System.IO.File.OpenRead(
            Constants.PathToFile.Sticker.Regular.VideoSecond
        );

        inputStickers.AddRange([
            new InputSticker(
                sticker: new InputFileId(classFixture.TestUploadedVideoStickerFile.FileId),
                emojiList: classFixture.FirstEmojis
            ),
            new InputSticker(
                sticker: new InputFileStream(stream, "Video2.webp"),
                emojiList: classFixture.SecondEmojis
            )
        ]);

        await BotClient.CreateNewStickerSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestVideoRegularStickerSetName,
            title: classFixture.TestStickerSetTitle,
            stickers: inputStickers,
            stickerFormat: StickerFormat.Video,
            stickerType: StickerType.Regular
        );

        await Task.Delay(1_000);

        classFixture.TestVideoRegularStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestVideoRegularStickerSetName
        );

        Assert.False(classFixture.TestVideoRegularStickerSet.IsAnimated);
        Assert.True(classFixture.TestVideoRegularStickerSet.IsVideo);
        Assert.True(classFixture.TestVideoRegularStickerSet.Stickers.Length == 2);
    }
    #endregion

    #region 3. Get and send stickers from a set
    [OrderedFact("Should send static sticker")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendSticker)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Send_Static_Sticker()
    {
        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Assert.False(stickerSet.IsAnimated);
        Assert.False(stickerSet.IsVideo);
        Assert.True(stickerSet.Stickers.Length is 2);

        Sticker firstSticker = stickerSet.Stickers.First();

        string firstEmojisString = string.Join(string.Empty, classFixture.FirstEmojis);

        Assert.Equal(firstEmojisString, firstSticker.Emoji);

        Message stickerMessage = await BotClient.SendStickerAsync(
            chatId: fixture.SupergroupChat.Id,
            sticker: new InputFileId(firstSticker.FileId)
        );

        Assert.Equal(MessageType.Sticker, stickerMessage.Type);
        Assert.NotNull(stickerMessage.Sticker);
        Assert.Equal(firstSticker.FileUniqueId, stickerMessage.Sticker.FileUniqueId);
        Assert.Equal(firstSticker.FileSize, stickerMessage.Sticker.FileSize);
        Assert.Equal(firstSticker.Type, stickerMessage.Sticker.Type);
        Assert.Equal(firstSticker.Width, stickerMessage.Sticker.Width);
        Assert.Equal(firstSticker.Height, stickerMessage.Sticker.Height);
        Assert.False(stickerMessage.Sticker.IsAnimated);
        Assert.False(stickerMessage.Sticker.IsVideo);
        Assert.NotNull(stickerMessage.Sticker.Thumbnail);
        Assert.NotNull(firstSticker.Thumbnail);
        Assert.Equal(firstSticker.Thumbnail.FileUniqueId, stickerMessage.Sticker.Thumbnail.FileUniqueId);
        Assert.Equal(firstSticker.Thumbnail.FileSize, stickerMessage.Sticker.Thumbnail.FileSize);
        Assert.Equal(firstSticker.Thumbnail.Width, stickerMessage.Sticker.Thumbnail.Width);
        Assert.Equal(firstSticker.Thumbnail.Height, stickerMessage.Sticker.Thumbnail.Height);
        Assert.Equal(firstSticker.Emoji, stickerMessage.Sticker.Emoji);
        Assert.Equal(firstSticker.SetName, stickerMessage.Sticker.SetName);
        Assert.Equal(firstSticker.MaskPosition, stickerMessage.Sticker.MaskPosition);
    }

    [OrderedFact("Should send animated sticker")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendSticker)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Send_Animated_Sticker()
    {
        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestAnimatedRegularStickerSetName
        );

        Assert.True(stickerSet.IsAnimated);
        Assert.False(stickerSet.IsVideo);
        Assert.True(stickerSet.Stickers.Length is 2);

        Sticker firstSticker = stickerSet.Stickers.First();

        string firstEmojisString = string.Join(string.Empty, classFixture.FirstEmojis);

        Assert.Equal(firstEmojisString, firstSticker.Emoji);

        Message stickerMessage = await BotClient.SendStickerAsync(
            chatId: fixture.SupergroupChat.Id,
            sticker: new InputFileId(firstSticker.FileId)
        );

        Assert.Equal(MessageType.Sticker, stickerMessage.Type);
        Assert.NotNull(stickerMessage.Sticker);
        Assert.Equal(firstSticker.FileUniqueId, stickerMessage.Sticker.FileUniqueId);
        Assert.Equal(firstSticker.FileSize, stickerMessage.Sticker.FileSize);
        Assert.Equal(firstSticker.Type, stickerMessage.Sticker.Type);
        Assert.Equal(firstSticker.Width, stickerMessage.Sticker.Width);
        Assert.Equal(firstSticker.Height, stickerMessage.Sticker.Height);
        Assert.True(stickerMessage.Sticker.IsAnimated);
        Assert.False(stickerMessage.Sticker.IsVideo);
        Assert.NotNull(firstSticker.Thumbnail);
        Assert.NotNull(stickerMessage.Sticker.Thumbnail);
        Assert.Equal(firstSticker.Thumbnail.FileUniqueId, stickerMessage.Sticker.Thumbnail.FileUniqueId);
        Assert.Equal(firstSticker.Thumbnail.FileSize, stickerMessage.Sticker.Thumbnail.FileSize);
        Assert.Equal(firstSticker.Thumbnail.Width, stickerMessage.Sticker.Thumbnail.Width);
        Assert.Equal(firstSticker.Thumbnail.Height, stickerMessage.Sticker.Thumbnail.Height);
        Assert.Equal(firstSticker.Emoji, stickerMessage.Sticker.Emoji);
        Assert.Equal(firstSticker.SetName, stickerMessage.Sticker.SetName);
        Assert.Equal(firstSticker.MaskPosition, stickerMessage.Sticker.MaskPosition);
    }

    [OrderedFact("Should send video sticker")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SendSticker)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Send_Video_Sticker()
    {
        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestVideoRegularStickerSetName
        );

        Assert.False(stickerSet.IsAnimated);
        Assert.True(stickerSet.IsVideo);
        Assert.True(stickerSet.Stickers.Length is 2);

        Sticker firstSticker = stickerSet.Stickers.First();

        string firstEmojisString = string.Join(string.Empty, classFixture.FirstEmojis);

        Assert.Equal(firstEmojisString, firstSticker.Emoji);

        Message stickerMessage = await BotClient.SendStickerAsync(
            chatId: fixture.SupergroupChat.Id,
            sticker: new InputFileId(firstSticker.FileId)
        );

        Assert.Equal(MessageType.Sticker, stickerMessage.Type);
        Assert.NotNull(stickerMessage.Sticker);
        Assert.Equal(firstSticker.FileUniqueId, stickerMessage.Sticker.FileUniqueId);
        Assert.Equal(firstSticker.FileSize, stickerMessage.Sticker.FileSize);
        Assert.Equal(firstSticker.Type, stickerMessage.Sticker.Type);
        Assert.Equal(firstSticker.Width, stickerMessage.Sticker.Width);
        Assert.Equal(firstSticker.Height, stickerMessage.Sticker.Height);
        Assert.False(stickerMessage.Sticker.IsAnimated);
        Assert.True(stickerMessage.Sticker.IsVideo);
        Assert.Equal(firstSticker.Thumbnail.FileUniqueId, stickerMessage.Sticker.Thumbnail.FileUniqueId);
        Assert.Equal(firstSticker.Thumbnail.FileSize, stickerMessage.Sticker.Thumbnail.FileSize);
        Assert.Equal(firstSticker.Thumbnail.Width, stickerMessage.Sticker.Thumbnail.Width);
        Assert.Equal(firstSticker.Thumbnail.Height, stickerMessage.Sticker.Thumbnail.Height);
        Assert.Equal(firstSticker.Emoji, stickerMessage.Sticker.Emoji);
        Assert.Equal(firstSticker.SetName, stickerMessage.Sticker.SetName);
        Assert.Equal(firstSticker.MaskPosition, stickerMessage.Sticker.MaskPosition);
    }
    #endregion

    #region 4. Add stickers to sets
    [OrderedFact("Should add sticker to static sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.AddStickerToSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Add_Sticker_To_Static_Sticker_Set()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(
            Constants.PathToFile.Sticker.Regular.StaticThird
        );

        InputSticker inputSticker = new InputSticker(
            sticker: new InputFileStream(stream, "Static3.png"),
            emojiList: classFixture.ThirdEmojis
        );

        await BotClient.AddStickerToSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestStaticRegularStickerSetName,
            sticker: inputSticker
        );

        await Task.Delay(1_000);

        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Assert.False(stickerSet.IsAnimated);
        Assert.False(stickerSet.IsVideo);
        Assert.True(stickerSet.Stickers.Length is 3);

        Sticker thirdSticker = stickerSet.Stickers[2];

        string thirdEmojisString = string.Join(string.Empty, classFixture.ThirdEmojis);

        Assert.Equal(thirdEmojisString, thirdSticker.Emoji);
        Assert.False(thirdSticker.IsAnimated);
        Assert.False(thirdSticker.IsVideo);
    }

    [OrderedFact("Should add sticker to animated sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.AddStickerToSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Add_Sticker_To_Animated_Sticker_Set()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(
            Constants.PathToFile.Sticker.Regular.AnimatedThird
        );

        InputSticker inputSticker = new InputSticker(
            sticker: new InputFileStream(stream, "Animated3.tgs"),
            emojiList: classFixture.ThirdEmojis
        );

        await BotClient.AddStickerToSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestAnimatedRegularStickerSetName,
            sticker: inputSticker
        );

        await Task.Delay(1_000);

        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestAnimatedRegularStickerSetName
        );

        Assert.True(stickerSet.IsAnimated);
        Assert.False(stickerSet.IsVideo);
        Assert.True(stickerSet.Stickers.Length is 3);

        Sticker thirdSticker = stickerSet.Stickers[2];

        string thirdEmojisString = string.Join(string.Empty, classFixture.ThirdEmojis);

        Assert.Equal(thirdEmojisString, thirdSticker.Emoji);
        Assert.True(thirdSticker.IsAnimated);
        Assert.False(thirdSticker.IsVideo);
    }

    [OrderedFact("Should add sticker to video sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.AddStickerToSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Add_Sticker_To_Video_Sticker_Set()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(
            Constants.PathToFile.Sticker.Regular.VideoThird
        );

        InputSticker inputSticker = new InputSticker(
            sticker: new InputFileStream(stream, "Video3.webm"),
            emojiList: classFixture.ThirdEmojis
        );

        await BotClient.AddStickerToSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestVideoRegularStickerSetName,
            sticker: inputSticker
        );

        await Task.Delay(1_000);

        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestVideoRegularStickerSetName
        );

        Assert.False(stickerSet.IsAnimated);
        Assert.True(stickerSet.IsVideo);
        Assert.True(stickerSet.Stickers.Length == 3);

        Sticker thirdSticker = stickerSet.Stickers[2];

        string thirdEmojisString = string.Join(string.Empty, classFixture.ThirdEmojis);

        Assert.Equal(thirdEmojisString, thirdSticker.Emoji);
        Assert.False(thirdSticker.IsAnimated);
        Assert.True(thirdSticker.IsVideo);
    }
    #endregion

    #region 5. Set sticker position in static set
    [OrderedFact("Should change sticker position in the test static regular sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SetStickerPositionInSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Change_Sticker_Position_In_Set()
    {
        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Sticker thirdSticker = stickerSet.Stickers[2];

        await BotClient.SetStickerPositionInSetAsync(
            sticker: new InputFileId(thirdSticker.FileId),
            position: 0
        );

        await Task.Delay(1_000);

        StickerSet positionedStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Sticker firstStickerInPositionedStickerSet = positionedStickerSet.Stickers.First();

        Assert.Equal(thirdSticker.FileUniqueId, firstStickerInPositionedStickerSet.FileUniqueId);
    }
    #endregion

    #region 6. Delete sticker from static set
    [OrderedFact("Should delete sticker from set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.DeleteStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Delete_Sticker_From_Set()
    {
        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Sticker thirdSticker = stickerSet.Stickers[2];

        await BotClient.DeleteStickerFromSetAsync(
            sticker: new InputFileId(thirdSticker.FileId)
        );

        await Task.Delay(1_000);

        StickerSet updatedStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Assert.DoesNotContain(updatedStickerSet.Stickers, s => s.FileId == thirdSticker.FileId);
    }
    #endregion

    #region 7. Set static first sticker emoji list
    [OrderedFact("Should set first sticker emoji list")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SetStickerEmojiList)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Set_First_Sticker_EmojiList()
    {
        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Sticker firstSticker = stickerSet.Stickers.First();

        string thirdEmojisString = string.Join(string.Empty, classFixture.ThirdEmojis);

        Assert.Equal(thirdEmojisString, firstSticker.Emoji);

        await BotClient.SetStickerEmojiListAsync(
            sticker: new InputFileId(firstSticker.FileId),
            emojiList: classFixture.FirstEmojis
        );

        await Task.Delay(1_000);

        StickerSet updatedStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Sticker updatedFirstSticker = updatedStickerSet.Stickers.First();

        string firstEmojisString = string.Join(string.Empty, classFixture.FirstEmojis);

        Assert.Equal(firstEmojisString, updatedFirstSticker.Emoji);
    }
    #endregion

    #region 8. Set static first sticker keywords
    [OrderedFact("Should set first sticker keywords")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SetStickerKeywords)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Set_First_Sticker_Keywords()
    {
        string[] keywords = ["test", "supertest"];

        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Sticker firstSticker = stickerSet.Stickers.First();

        await BotClient.SetStickerKeywordsAsync(
            sticker: new InputFileId(firstSticker.FileId),
            keywords: keywords
        );

        await Task.Delay(1_000);

        await BotClient.SetStickerKeywordsAsync(
            sticker: new InputFileId(firstSticker.FileId),
            keywords: null
        );
    }
    #endregion

    #region 9. Set static sticker set title
    [OrderedFact("Should set sticker set title")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SetStickerSetTitle)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Set_Sticker_Set_Title()
    {
        const string newStickerSetTitle = "New title for sticker set";

        await BotClient.SetStickerSetTitleAsync(
            name: classFixture.TestStaticRegularStickerSetName,
            title: newStickerSetTitle
        );

        await Task.Delay(1_000);

        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Assert.Equal(newStickerSetTitle, stickerSet.Title);
    }
    #endregion

    #region 10. Set static sticker set thumbnail
    [OrderedFact("Should set sticker set thumbnail")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SetStickerSetThumbnail)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Set_Sticker_Set_Thumbnail()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(
            Constants.PathToFile.Sticker.Regular.StaticThumbnail
        );

        await BotClient.SetStickerSetThumbnailAsync(
            name: classFixture.TestStaticRegularStickerSetName,
            userId: classFixture.OwnerUserId,
            thumbnail: new InputFileStream(stream)
        );

        await Task.Delay(1_000);

        StickerSet updatedStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Assert.NotNull(updatedStickerSet.Thumbnail);
        Assert.True(updatedStickerSet.Thumbnail.FileSize > 0);
    }
    #endregion

    #region 11. Some exceptions
    [OrderedFact("Should throw " + nameof(ApiRequestException) +
                 " while trying to create sticker set with name not ending in _by_<bot username>")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    public async Task Should_Throw_InvalidStickerSetNameException()
    {
        const string expectedExceptionMessage = "Bad Request: invalid sticker set name is specified";

        List<InputSticker> inputStickers =
        [
            new InputSticker(
                sticker: new InputFileId(classFixture.TestUploadedStaticStickerFile.FileId),
                emojiList: classFixture.FirstEmojis
            )
        ];

        ApiRequestException exception = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.CreateNewStickerSetAsync(
                userId: classFixture.OwnerUserId,
                name: "Invalid_Sticker_Set_Name",
                title: classFixture.TestStickerSetTitle,
                stickers: inputStickers,
                stickerFormat: StickerFormat.Static
            )
        );

        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [OrderedFact("Should throw " + nameof(ApiRequestException) +
                 " while trying to create sticker with invalid emoji")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    public async Task Should_Throw_InvalidStickerEmojisException()
    {
        const string expectedExceptionMessage = "Bad Request: can't parse InputSticker: expected a Unicode emoji";

        string[] invalidEmojis = ["INVALID"];

        List<InputSticker> inputStickers =
        [
            new InputSticker(
                sticker: new InputFileId(classFixture.TestUploadedStaticStickerFile.FileId),
                emojiList: invalidEmojis
            )
        ];

        ApiRequestException exception = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.CreateNewStickerSetAsync(
                userId: classFixture.OwnerUserId,
                name: classFixture.TestStaticRegularStickerSetName,
                title: classFixture.TestStickerSetTitle,
                stickers: inputStickers,
                stickerFormat: StickerFormat.Static
            )
        );

        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [OrderedFact("Should throw " + nameof(ApiRequestException) +
                 " while trying to create sticker with invalid dimensions")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    public async Task Should_Throw_InvalidStickerDimensionsException()
    {
        // ToDo exception when sending jpeg file. Bad Request: STICKER_PNG_NOPNG

        const string expectedExceptionMessage = "Bad Request: STICKER_PNG_DIMENSIONS";

        await using System.IO.Stream stream = System.IO.File.OpenRead(Constants.PathToFile.Photos.Logo);

        List<InputSticker> inputStickers =
        [
            new InputSticker(
                sticker: new InputFileStream(stream, "logo.png"),
                emojiList: classFixture.FirstEmojis
            )
        ];

        //New name, because an exception might be thrown: Bad Request: sticker set name is already occupied
        string newStickerSetName = $"new_{classFixture.TestStaticRegularStickerSetName}";

        ApiRequestException exception = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.CreateNewStickerSetAsync(
                userId: classFixture.OwnerUserId,
                name: newStickerSetName,
                title: classFixture.TestStickerSetTitle,
                stickers: inputStickers,
                stickerFormat: StickerFormat.Static
            )
        );

        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [OrderedFact("Should throw " + nameof(ApiRequestException) +
                 " while trying to create sticker with invalid file size")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    public async Task Should_Throw_InvalidFileSizeException()
    {
        const string expectedExceptionMessage = "Bad Request: file is too big";

        await using System.IO.Stream stream = System.IO.File.OpenRead(Constants.PathToFile.Photos.Apes);

        List<InputSticker> inputStickers =
        [
            new InputSticker(
                sticker: new InputFileStream(stream, "apes.jpg"),
                emojiList: classFixture.FirstEmojis
            )
        ];

        ApiRequestException exception = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.CreateNewStickerSetAsync(
                userId: classFixture.OwnerUserId,
                name: classFixture.TestStaticRegularStickerSetName,
                title: classFixture.TestStickerSetTitle,
                stickers: inputStickers,
                stickerFormat: StickerFormat.Static
            )
        );

        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [OrderedFact("Should throw " + nameof(ApiRequestException) +
                 " while trying to create sticker set with the same name with ruby photo", Skip = "Bot API Bug")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    public async Task Should_Throw_StickerSetNameExistsException()
    {

        const string expectedExceptionMessage = "Bad Request: sticker set name is already occupied";

        await using System.IO.Stream stream = System.IO.File.OpenRead(Constants.PathToFile.Photos.Ruby);

        List<InputSticker> inputStickers =
        [
            new InputSticker(
                sticker: new InputFileStream(stream, "ruby.png"),
                emojiList: classFixture.FirstEmojis
            )
        ];

        // Telegram for some reason does not return an error, so the test is skipped
        ApiRequestException exception = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.CreateNewStickerSetAsync(
                userId: classFixture.OwnerUserId,
                name: classFixture.TestStaticRegularStickerSetName,
                title: classFixture.TestStickerSetTitle,
                stickers: inputStickers,
                stickerFormat: StickerFormat.Static
            )
        );

        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [OrderedFact("Should throw " + nameof(ApiRequestException) +
                 " while trying to remove the last sticker in the set twice")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.DeleteStickerFromSet)]
    public async Task Should_Throw_StickerSetNotModifiedException()
    {
        const string expectedExceptionMessage = "Bad Request: STICKERSET_NOT_MODIFIED";

        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        Sticker lastSticker = stickerSet.Stickers.Last();

        await BotClient.DeleteStickerFromSetAsync(
            sticker: new InputFileId(lastSticker.FileId)
        );

        ApiRequestException exception = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.DeleteStickerFromSetAsync(
                sticker: new InputFileId(lastSticker.FileId)
            )
        );

        Assert.Equal(expectedExceptionMessage, exception.Message);
    }
    #endregion

    #region 12. Delete sticker sets
    [OrderedFact("Should delete sticker sets")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.DeleteStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Delete_Sticker_Sets()
    {
        const string expectedExceptionMessage = "Bad Request: STICKERSET_INVALID";

        await BotClient.DeleteStickerSetAsync(
            name: classFixture.TestStaticRegularStickerSetName
        );

        await BotClient.DeleteStickerSetAsync(
            name: classFixture.TestAnimatedRegularStickerSetName
        );

        await BotClient.DeleteStickerSetAsync(
            name: classFixture.TestVideoRegularStickerSetName
        );

        await Task.Delay(1_000);

        ApiRequestException staticException = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.GetStickerSetAsync(
                name: classFixture.TestStaticRegularStickerSetName
            )
        );

        ApiRequestException animatedException = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.GetStickerSetAsync(
                name: classFixture.TestAnimatedRegularStickerSetName
            )
        );

        ApiRequestException videoException = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.GetStickerSetAsync(
                name: classFixture.TestVideoRegularStickerSetName
            )
        );

        Assert.Equal(expectedExceptionMessage, staticException.Message);
        Assert.Equal(expectedExceptionMessage, animatedException.Message);
        Assert.Equal(expectedExceptionMessage, videoException.Message);
    }
    #endregion

    #region 13. Mask tests
    [OrderedFact("Shound create new mask static sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Create_New_Mask_Static_Sticker_Set()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(
            Constants.PathToFile.Photos.Tux
        );

        List<InputSticker> inputStickers =
        [
            new InputSticker(
                sticker: new InputFileStream(stream, "tux.png"),
                emojiList: classFixture.SecondEmojis
            )
        ];

        await BotClient.CreateNewStickerSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestStaticMaskStickerSetName,
            title: classFixture.TestStickerSetTitle,
            stickers: inputStickers,
            stickerFormat: StickerFormat.Static,
            stickerType: StickerType.Mask
        );

        await Task.Delay(1_000);

        classFixture.TestStaticMaskStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticMaskStickerSetName
        );

        Assert.Equal(StickerType.Mask, classFixture.TestStaticMaskStickerSet.StickerType);
        Assert.False(classFixture.TestStaticMaskStickerSet.IsAnimated);
        Assert.False(classFixture.TestStaticMaskStickerSet.IsVideo);
        Assert.True(classFixture.TestStaticMaskStickerSet.Stickers.Length == 1);
    }

    [OrderedFact("Should add VLC logo sticker with mask position like hat on forehead")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.AddStickerToSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Add_Sticker_With_Mask_Position_To_Set()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(Constants.PathToFile.Photos.Vlc);

        InputSticker inputSticker = new InputSticker(
            sticker: new InputFileStream(stream, "vlc.png"),
            emojiList: classFixture.SecondEmojis
        )
        {
            MaskPosition = new MaskPosition
            {
                Point = MaskPositionPoint.Forehead,
                Scale = .8f
            }
        };

        await BotClient.AddStickerToSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestStaticMaskStickerSetName,
            sticker: inputSticker
        );

        await Task.Delay(1_000);

        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticMaskStickerSetName
        );

        Assert.Equal(StickerType.Mask, stickerSet.StickerType);
        Assert.False(stickerSet.IsAnimated);
        Assert.False(stickerSet.IsVideo);
        Assert.True(stickerSet.Stickers.Length == 2);

        Sticker sticker = stickerSet.Stickers.Last();

        Assert.NotNull(sticker.MaskPosition);
        Assert.Equal(MaskPositionPoint.Forehead, sticker.MaskPosition.Point);
        Assert.Equal(.8f, sticker.MaskPosition.Scale);
    }

    [OrderedFact("Should set mask position for first sticker")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.AddStickerToSet)]
    public async Task Should_Set_Mask_Position_From_Last_Sticker()
    {
        MaskPosition newMaskPosition = new MaskPosition
        {
            Point = MaskPositionPoint.Chin,
            Scale = .42f
        };

        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticMaskStickerSetName
        );

        Sticker sticker = stickerSet.Stickers.First();

        await BotClient.SetStickerMaskPositionAsync(
            sticker: new InputFileId(sticker.FileId),
            maskPosition: newMaskPosition
        );

        await Task.Delay(1_000);

        StickerSet changedStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticMaskStickerSetName
        );

        Sticker changedSticker = changedStickerSet.Stickers.First();

        Assert.NotNull(changedSticker.MaskPosition);
        Assert.Equal(newMaskPosition.Point, changedSticker.MaskPosition.Point);
        Assert.Equal(newMaskPosition.Scale, changedSticker.MaskPosition.Scale);
    }

    [OrderedFact("Should delete mask sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.DeleteStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Delete_Mask_Sticker_Set()
    {
        const string expectedExceptionMessage = "Bad Request: STICKERSET_INVALID";

        await BotClient.DeleteStickerSetAsync(
            name: classFixture.TestStaticMaskStickerSetName
        );

        await Task.Delay(1_000);

        ApiRequestException exception = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.GetStickerSetAsync(
                name: classFixture.TestStaticMaskStickerSetName
            )
        );

        Assert.Equal(expectedExceptionMessage, exception.Message);
    }
    #endregion

    #region 14. Custom emoji tests
    [OrderedFact("Shound create new custom emoji static sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.CreateNewStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Create_New_Custom_Emoji_Static_Sticker_Set()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(
            Constants.PathToFile.Sticker.CustomEmoji.StaticFirst
        );

        List<InputSticker> inputStickers =
        [
            new InputSticker(
                sticker: new InputFileStream(stream, "Static1.png"),
                emojiList: classFixture.FirstEmojis
            )
        ];

        await BotClient.CreateNewStickerSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestStaticCustomEmojiStickerSetName,
            title: classFixture.TestStickerSetTitle,
            stickers: inputStickers,
            stickerFormat: StickerFormat.Static,
            stickerType: StickerType.CustomEmoji
        );

        await Task.Delay(1_000);

        classFixture.TestStaticCustomEmojiStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticCustomEmojiStickerSetName
        );

        Assert.Equal(StickerType.CustomEmoji, classFixture.TestStaticCustomEmojiStickerSet.StickerType);
        Assert.False(classFixture.TestStaticCustomEmojiStickerSet.IsAnimated);
        Assert.False(classFixture.TestStaticCustomEmojiStickerSet.IsVideo);
        Assert.True(classFixture.TestStaticCustomEmojiStickerSet.Stickers.Length == 1);
    }

    [OrderedFact("Should add sticker to a custom emoji set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.AddStickerToSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Add_Sticker_To_A_Custom_Emoji_set()
    {
        await using System.IO.Stream stream = System.IO.File.OpenRead(Constants.PathToFile.Sticker.CustomEmoji.StaticSecond);

        InputSticker inputSticker = new InputSticker(
            sticker: new InputFileStream(stream, "Static2.png"),
            emojiList: classFixture.SecondEmojis
        );

        await BotClient.AddStickerToSetAsync(
            userId: classFixture.OwnerUserId,
            name: classFixture.TestStaticCustomEmojiStickerSetName,
            sticker: inputSticker
        );

        await Task.Delay(1_000);

        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticCustomEmojiStickerSetName
        );

        Assert.Equal(StickerType.CustomEmoji, stickerSet.StickerType);
        Assert.False(stickerSet.IsAnimated);
        Assert.False(stickerSet.IsVideo);
        Assert.True(stickerSet.Stickers.Length == 2);

        Sticker sticker = stickerSet.Stickers.Last();

        Assert.NotNull(sticker.CustomEmojiId);
    }

    [OrderedFact("Should set custom emoji set thumbnail")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.SetCustomEmojiStickerSetThumbnail)]
    public async Task Should_Set_Custom_Emoji_Set_Thumbnail()
    {
        StickerSet stickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticCustomEmojiStickerSetName
        );

        Sticker lastSticker = stickerSet.Stickers.Last();

        Assert.NotNull(lastSticker.CustomEmojiId);

        await BotClient.SetCustomEmojiStickerSetThumbnailAsync(
            name: classFixture.TestStaticCustomEmojiStickerSetName,
            customEmojiId: lastSticker.CustomEmojiId
        );

        StickerSet changedStickerSet = await BotClient.GetStickerSetAsync(
            name: classFixture.TestStaticCustomEmojiStickerSetName
        );

        Assert.NotNull(changedStickerSet.Thumbnail);
        Assert.NotNull(changedStickerSet.Thumbnail.FileSize);
        Assert.True(changedStickerSet.Thumbnail.FileSize > 0);
        Assert.True(changedStickerSet.Thumbnail.Width == 100);
        Assert.True(changedStickerSet.Thumbnail.Height == 100);
    }

    [OrderedFact("Should delete custom emoji sticker set")]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.DeleteStickerSet)]
    [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.GetStickerSet)]
    public async Task Should_Delete_Custom_Emoji_Sticker_Set()
    {
        const string expectedExceptionMessage = "Bad Request: STICKERSET_INVALID";

        await BotClient.DeleteStickerSetAsync(
            name: classFixture.TestStaticCustomEmojiStickerSetName
        );

        await Task.Delay(1_000);

        ApiRequestException exception = await Assert.ThrowsAsync<ApiRequestException>(() =>
            BotClient.GetStickerSetAsync(
                name: classFixture.TestStaticCustomEmojiStickerSetName
            )
        );

        Assert.Equal(expectedExceptionMessage, exception.Message);
    }
    #endregion
}

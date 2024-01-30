using System;
using System.IO;
using System.Text.Json;
using Telegram.Bot.Converters;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.Serialization;

public class InputFileSerializationTests
{
    [Fact(DisplayName = "Should serialize & deserialize input file from stream")]
    public void Should_Serialize_InputFile()
    {
        const string fileName = "myFile";
        InputFileStream inputFile = new(new MemoryStream(), fileName);

        string json = JsonSerializer.Serialize(inputFile, JsonSerializerOptionsProvider.Options);
        InputFileStream obj = JsonSerializer.Deserialize<InputFileStream>(json, JsonSerializerOptionsProvider.Options)!;

        Assert.Equal(@$"""attach://{fileName}""", json);
        Assert.Equal(Stream.Null, obj.Content);
        Assert.Equal(fileName, obj.FileName);
        Assert.Equal(FileType.Stream, obj.FileType);
    }

    [Fact(DisplayName = "Should serialize & deserialize input file with file_id")]
    public void Should_Serialize_FileId()
    {
        const string fileId = "This-is-a-file_id";
        InputFileId inputFileId = new(fileId);

        string json = JsonSerializer.Serialize(inputFileId, JsonSerializerOptionsProvider.Options);
        InputFileId? obj = JsonSerializer.Deserialize<InputFileId>(json, JsonSerializerOptionsProvider.Options);

        Assert.NotNull(obj);
        Assert.Equal(fileId, obj.Id);
        Assert.Equal(FileType.Id, obj.FileType);
    }

    [Fact(DisplayName = "Should serialize & deserialize input file with URL")]
    public void Should_Serialize_InputUrlFile()
    {
        Uri url = new("http://github.org/TelegramBots");
        InputFileUrl inputFileUrl = new(url);

        string json = JsonSerializer.Serialize(inputFileUrl, JsonSerializerOptionsProvider.Options);
        InputFileUrl? obj = JsonSerializer.Deserialize<InputFileUrl>(json, JsonSerializerOptionsProvider.Options);

        Assert.NotNull(obj);
        Assert.Equal(url, obj.Url);
        Assert.Equal(FileType.Url, obj.FileType);
    }
}

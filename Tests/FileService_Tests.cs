using Shared.Interfaces;
using Shared.Services;

namespace Tests;
public class FileService_Tests
{
    [Fact]
    public void WriteFile_ShouldWriteContentToFile()
    {
        IFileService service = new FileService(@"C:\Users\Emanuel");

        service.WriteFile("hi again", "WriteLines.txt");
    }
    [Fact]
    public void ReadFile_ShouldReadAFile_ReturnTheText()
    {
        IFileService service = new FileService(@"C:\Users\Emanuel");
        string text = service.ReadFile("WriteLines.txt");
        Console.WriteLine(text);
        Assert.NotEmpty(text);
        Assert.IsType<string>(text);
    }
}

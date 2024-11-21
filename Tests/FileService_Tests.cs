using Shared.Interfaces;
using Shared.Services;

namespace Tests;
public class FileService_Tests
{
    [Fact]
    public void saveFile()
    {
        IFileService service = new FileService();

        service.WriteFile("hello world");

    }
}

using Shared.Interfaces;

namespace Shared.Services;
public class FileService : IFileService
{
    string _filePath = @"C:\Users\Emanuel";
    public string ReadFile()
    {
        throw new NotImplementedException();

    }

    public void WriteFile(string content)
    {
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(_filePath, "WriteLines.txt")))
        {
            outputFile.WriteLine(content);
        }
    }
}

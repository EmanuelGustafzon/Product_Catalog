namespace Shared.Interfaces;
public interface IFileService
{
    void WriteFile(string content, string filePath);
    string ReadFile(string fileName);
}

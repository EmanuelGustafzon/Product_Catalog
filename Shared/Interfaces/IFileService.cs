namespace Shared.Interfaces;
public interface IFileService
{
    void WriteFile(string content);
    string ReadFile();
}

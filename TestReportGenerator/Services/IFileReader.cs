namespace TestReportGenerator.Services;

public interface IFileReader
{
    string ReadFile(string path);
    string[] ReadAllLines(string path);
    bool FileExists(string path);
}

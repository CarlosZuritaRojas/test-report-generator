namespace TestReportGenerator.Services.Implementations;

public class FileReader : IFileReader
{
    public string ReadFile(string path) => File.ReadAllText(path);
    public string[] ReadAllLines(string path) => File.ReadAllLines(path);
    public bool FileExists(string path) => File.Exists(path);
}
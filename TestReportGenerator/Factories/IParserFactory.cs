namespace TestReportGenerator.Factories;

public interface IParserFactory
{
    ITestResultParser GetParser(string fileExtension);
}
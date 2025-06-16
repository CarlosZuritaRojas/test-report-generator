using TestReportGenerator.Factories;
using TestReportGenerator.Parsers;
using TestReportGenerator.Services.Parsers;

namespace TestReportGenerator.Services.Implementations;

public class ParserFactory : IParserFactory
{

    public ITestResultParser GetParser(string extension)
    {
        return extension.ToLower() switch
        {
            ".csv" => new CsvParser(),
            ".json" => new JsonParser(),
            ".xml" => new XmlParser(),
            _ => throw new NotSupportedException()
        };
    }
}
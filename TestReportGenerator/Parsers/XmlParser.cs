using System.Xml.Linq;
using TestReportGenerator.Models;

namespace TestReportGenerator.Parsers;
public class XmlParser : ITestResultParser
{
    public List<TestResult> Parse(string content)
    {
        var results = new List<TestResult>();
        var xmlDoc = XDocument.Parse(content);

        var testElements = xmlDoc.Descendants("test");

        foreach (var element in testElements)
        {
            results.Add(new TestResult
            {
                TestName = element.Element("testName")?.Value,
                Status = element.Element("status")?.Value,
                Duration = double.TryParse(element.Element("duration")?.Value, out var d) ? d : 0,
                Category = element.Element("category")?.Value,
                Priority = element.Element("priority")?.Value
            });
        }

        return results;
    }
}

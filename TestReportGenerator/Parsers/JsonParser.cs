
using System.Text.Json;
using TestReportGenerator.Models;

namespace TestReportGenerator.Parsers;

public class JsonParser : ITestResultParser
{
    public List<TestResult> Parse(string content)
    {
        var results = new List<TestResult>();

        using var document = JsonDocument.Parse(content);
        if (document.RootElement.TryGetProperty("tests", out var tests))
        {
            foreach (var test in tests.EnumerateArray())
            {
                results.Add(new TestResult
                {
                    TestName = test.GetProperty("testName").GetString(),
                    Status = test.GetProperty("status").GetString(),
                    Duration = test.GetProperty("duration").GetDouble(),
                    Category = test.GetProperty("category").GetString(),
                    Priority = test.GetProperty("priority").GetString()
                });
            }
        }

        return results;
    }
}
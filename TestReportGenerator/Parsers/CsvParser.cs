using TestReportGenerator.Models;

namespace TestReportGenerator.Services.Parsers;

public class CsvParser : ITestResultParser
{
    public List<TestResult> Parse(string content)
    {
        var results = new List<TestResult>();
        var lines = content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');
            if (parts.Length >= 5)
            {
                results.Add(new TestResult
                {
                    TestName = parts[0],
                    Status = parts[1],
                    Duration = double.Parse(parts[2]),
                    Category = parts[3],
                    Priority = parts[4]
                });
            }
        }

        return results;
    }
}
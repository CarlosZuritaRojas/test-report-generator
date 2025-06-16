using TestReportGenerator.Decorators;
using TestReportGenerator.Models;

public class FailedTestsSection : IReportSection
{
    public void WriteSection(List<TestResult> results)
    {
        var failed = results.Where(r => r.Status == "FAILED");
        if (failed.Any())
        {
            Console.WriteLine("\nFailed Tests:");
            foreach (var test in failed)
            {
                Console.WriteLine($"- {test.TestName} ({test.Duration}s) - {test.Category}");
            }
        }
    }
}
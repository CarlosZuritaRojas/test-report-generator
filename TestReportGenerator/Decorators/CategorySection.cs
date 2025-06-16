using TestReportGenerator.Decorators;
using TestReportGenerator.Models;

public class CategorySection : IReportSection
{
    public void WriteSection(List<TestResult> results)
    {
        Console.WriteLine("\nBy Category:");
        var groups = results.GroupBy(r => r.Category);
        foreach (var g in groups)
        {
            int passed = g.Count(r => r.Status == "PASSED");
            Console.WriteLine($"- {g.Key}: {passed}/{g.Count()} passed");
        }
    }
}
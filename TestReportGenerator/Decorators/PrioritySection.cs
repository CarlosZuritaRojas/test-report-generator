using System;
using TestReportGenerator.Decorators;
using TestReportGenerator.Models;
public class PrioritySection : IReportSection
{
    public void WriteSection(List<TestResult> results)
    {
        Console.WriteLine("\nBy Priority:");
        var groups = results.GroupBy(r => r.Priority);
        foreach (var g in groups)
        {
            int passed = g.Count(r => r.Status == "PASSED");
            Console.WriteLine($"- {g.Key}: {passed}/{g.Count()} passed");
        }
    }
}
using TestReportGenerator.Decorators;
using TestReportGenerator.Models;

public class SummarySection : IReportSection
{
    public void WriteSection(List<TestResult> results)
    {
        int total = results.Count;
        int passed = results.Count(r => r.Status == "PASSED");
        int failed = total - passed;
        double passRate = total > 0 ? (double)passed / total * 100 : 0;

        Console.WriteLine($"""
        Total Tests: {total}
        ✅ Passed: {passed} ({passRate:F2}%)
        ❌ Failed: {failed} ({100 - passRate:F2}%)
        """);
    }
}
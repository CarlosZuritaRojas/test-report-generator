using TestReportGenerator.Decorators;
using TestReportGenerator.Models;

public class ReportGenerator : IReportGenerator
{
    private readonly IEnumerable<IReportSection> _sections;

    public ReportGenerator(IEnumerable<IReportSection> sections)
    {
        _sections = sections;
    }

    public void Generate(List<TestResult> results)
    {
        Console.WriteLine($"""
        ==========================================
                 TEST EXECUTION REPORT
        ==========================================
        """);

        foreach (var section in _sections)
        {
            section.WriteSection(results);
        }

        Console.WriteLine("==========================================\n");
    }
}
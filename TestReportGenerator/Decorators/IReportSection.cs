
using TestReportGenerator.Models;

namespace TestReportGenerator.Decorators;

public interface IReportSection
{
    void WriteSection(List<TestResult> results);
}

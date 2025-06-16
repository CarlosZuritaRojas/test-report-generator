using TestReportGenerator.Models;

public interface ITestAnalyzer
{
    void Analyze(List<TestResult> results);
}
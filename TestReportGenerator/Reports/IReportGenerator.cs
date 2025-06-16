using TestReportGenerator.Models;

public interface IReportGenerator
{
    void Generate(List<TestResult> results);
}
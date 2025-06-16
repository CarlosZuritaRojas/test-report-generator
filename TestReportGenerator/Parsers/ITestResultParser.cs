using TestReportGenerator.Models;

public interface ITestResultParser
{
    List<TestResult> Parse(string content);
}

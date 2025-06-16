using System.Text.Json;
using System.Xml.Linq;
using TestReportGenerator.Abstractions;
using TestReportGenerator.Factories;
using TestReportGenerator.Models;
using TestReportGenerator.Services;

namespace TestReportGenerator;

// TODO: This class violates Single Responsibility Principle (SRP)
// It handles CLI logic, file reading, parsing, analysis, and report generation
// HINT: Extract responsibilities into separate services injected via constructor
public class ReportGeneratorCli(
    IFileReader fileReader,
    IParserFactory parserFactory,
    IReportGenerator reportGenerator) : IReportGeneratorCli
{
    // TODO: No constructor injection - violates Dependency Injection best practices
    // HINT: Add constructor with required dependencies
    private readonly IFileReader _fileReader = fileReader;
    private readonly IParserFactory _parserFactory = parserFactory;
    private readonly IReportGenerator _reportGenerator = reportGenerator;

    public void Run(string[] args)
    {
        Console.WriteLine("Test Report Generator v1.0");
        Console.WriteLine("==========================\n");

        // TODO: Basic argument handling - could be improved with proper validation
        // HINT: Consider using a command-line parser library
        if (args.Length == 0)
        {
            Console.WriteLine("""
      Usage: TestReportGenerator <test_results_file>
      Supported formats: .csv, .json, .xml

      Example: TestReportGenerator test_results.csv
      """);

            return;
        }

        string inputFile = args[0];

        // TODO: File existence check before processing
        // HINT: This should be in a separate validation method

        if (!_fileReader.FileExists(inputFile)) return;
        var parser = _parserFactory.GetParser(inputFile);
        var results = parser.Parse(inputFile);
        _reportGenerator.Generate(results);
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
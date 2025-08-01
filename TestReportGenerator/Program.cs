﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestReportGenerator;
using TestReportGenerator.Factories;
using TestReportGenerator.Services.Implementations;
using TestReportGenerator.Services;
using TestReportGenerator.Analysis;
using TestReportGenerator.Parsers;
using TestReportGenerator.Services.Parsers;
using TestReportGenerator.Abstractions;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;

// TODO: This service registration violates Dependency Inversion Principle (DIP)
// We're registering concrete classes instead of interfaces
// HINT: Create interfaces for all services and register them properly
services.AddSingleton<IFileReader, FileReader>();
services.AddSingleton<IParserFactory, ParserFactory>();
services.AddSingleton<ITestResultParser, CsvParser>();
services.AddSingleton<ITestResultParser, JsonParser>();
services.AddSingleton<ITestResultParser, XmlParser>();
services.AddSingleton<IReportGenerator, ReportGenerator>();
services.AddSingleton<ITestAnalyzer, TestAnalyzer>();
services.AddSingleton<IReportGeneratorCli, ReportGeneratorCli>();

services.AddSingleton<ReportGeneratorCli>();

// TODO: No other services are registered - violates proper DI setup
// The ReportGeneratorCli class will have to create all its dependencies
// HINT: Register all dependencies (parsers, generators, analyzers) here
using var host = builder.Build();

// Run the CLI application
host.Services.GetRequiredService<ReportGeneratorCli>().Run(args);

// TODO: Missing interfaces that should be created:
// - IFileReader: For file operations
// - ITestResultParser: Base interface for parsers
// - IParserFactory: For creating appropriate parsers
// - IReportGenerator: For generating reports
// - ITestAnalyzer: For analyzing test results
// - IReportSection: For decorator pattern implementation

// TODO: Missing service implementations that violate SOLID:
// Currently all logic is in ReportGeneratorCli class
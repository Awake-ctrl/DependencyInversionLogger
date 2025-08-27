using System;
using System.IO;
using DependencyInversionLogger;
using Xunit;

public class ConsoleLoggerTests : IDisposable
{
    private readonly TextWriter _originalOut;

    public ConsoleLoggerTests()
    {
        // Save original Console.Out
        _originalOut = Console.Out;
    }

    public void Dispose()
    {
        // Always restore Console.Out after each test
        Console.SetOut(_originalOut);
    }

    [Fact]
    public void ConsoleLogger_Should_LogMessage_WithoutException()
    {
        var logger = new ConsoleLogger();
        var exception = Record.Exception(() => logger.Log("Hello Console!"));
        Assert.Null(exception);
    }

    [Fact]
    public void ConsoleLogger_Should_WriteToConsoleOutput()
    {
        var logger = new ConsoleLogger();
        var testMessage = "Console Test Message";

        using var sw = new StringWriter();
        Console.SetOut(sw);

        logger.Log(testMessage);

        var output = sw.ToString();
        Assert.Contains(testMessage, output);
    }

    [Fact]
    public void ConsoleLogger_Should_HandleEmptyMessage()
    {
        var logger = new ConsoleLogger();
        var exception = Record.Exception(() => logger.Log(""));
        Assert.Null(exception); // should not throw
    }

    [Fact]
    public void ConsoleLogger_Should_HandleNullMessage()
    {
        var logger = new ConsoleLogger();
        var exception = Record.Exception(() => logger.Log(null));
        Assert.Null(exception); // logger should handle null safely
    }
}

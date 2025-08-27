/******************************************************************************
 * Filename    = ConsoleLoggerTests.cs
 *
 * Author      = Kallepally Sai Kiran
 *
 * Product     = DependencyInversionLogger
 * 
 * Project     = UnitTests
 *
 * Description = Unit tests for the ConsoleLogger implementation.
 *****************************************************************************/

using System;
using System.IO;
using DependencyInversionLogger;
using Xunit;

/// <summary>
/// Unit tests for the <see cref="ConsoleLogger"/>.
/// </summary>
public class ConsoleLoggerTests : IDisposable
{
    private readonly TextWriter _originalOut;

    /// <summary>
    /// Initializes a new instance of the test class.
    /// Saves the original console output writer.
    /// </summary>
    public ConsoleLoggerTests()
    {
        _originalOut = Console.Out;
    }

    /// <summary>
    /// Restores the original console output after each test.
    /// </summary>
    public void Dispose()
    {
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
        Assert.Null(exception);
    }

    [Fact]
    public void ConsoleLogger_Should_HandleNullMessage()
    {
        var logger = new ConsoleLogger();
        var exception = Record.Exception(() => logger.Log(null));
        Assert.Null(exception);
    }
}

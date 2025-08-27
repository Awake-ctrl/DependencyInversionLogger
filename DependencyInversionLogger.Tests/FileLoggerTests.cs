/******************************************************************************
 * Filename    = FileLoggerTests.cs
 *
 * Author      = Kallepally Sai Kiran
 *
 * Product     = DependencyInversionLogger
 * 
 * Project     = UnitTests
 *
 * Description = Unit tests for the FileLogger implementation.
 *****************************************************************************/

using System.IO;
using DependencyInversionLogger;
using Xunit;

/// <summary>
/// Unit tests for the <see cref="FileLogger"/>.
/// </summary>
public class FileLoggerTests
{
    private readonly string logFile = "testlog.log";

    /// <summary>
    /// Initializes a new instance of the test class.
    /// Ensures a clean state by deleting the test log file if it exists.
    /// </summary>
    public FileLoggerTests()
    {
        if (File.Exists(logFile))
            File.Delete(logFile);
    }

    [Fact]
    public void FileLogger_Should_CreateLogFile()
    {
        var logger = new FileLogger(logFile);
        logger.Log("Creating file test");
        Assert.True(File.Exists(logFile));
    }

    [Fact]
    public void FileLogger_Should_WriteMessageToFile()
    {
        var logger = new FileLogger(logFile);
        var message = "Hello File Logger";
        logger.Log(message);

        var content = File.ReadAllText(logFile);
        Assert.Contains(message, content);
    }

    [Fact]
    public void FileLogger_Should_AppendMessages()
    {
        var logger = new FileLogger(logFile);
        logger.Log("First message");
        logger.Log("Second message");

        var content = File.ReadAllText(logFile);
        Assert.Contains("First message", content);
        Assert.Contains("Second message", content);
    }

    [Fact]
    public void FileLogger_Should_HandleEmptyMessage()
    {
        var logger = new FileLogger(logFile);
        logger.Log("");
        var content = File.ReadAllText(logFile);
        Assert.NotNull(content);
    }

    [Fact]
    public void FileLogger_Should_HandleMultipleLogs()
    {
        var logger = new FileLogger(logFile);

        for (int i = 0; i < 5; i++)
            logger.Log($"Message {i}");

        var content = File.ReadAllText(logFile);
        for (int i = 0; i < 5; i++)
            Assert.Contains($"Message {i}", content);
    }
}

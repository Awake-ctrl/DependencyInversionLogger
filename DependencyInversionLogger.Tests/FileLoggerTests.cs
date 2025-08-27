// =============================
// Dependency Inversion Logger
// Tests for FileLogger
// Author: Kallepally Sai Kiran (112201044)
// =============================

using System.IO;
using DependencyInversionLogger;
using Xunit;

public class FileLoggerTests
{
    private readonly string logFile = "testlog.log";

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
        Assert.NotNull(content); // file still valid even if empty string logged
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

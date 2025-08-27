/******************************************************************************
 * Filename    = FileLogger.cs
 *
 * Author      = Kallepally Sai Kiran
 *
 * Product     = DependencyInversionLogger
 * 
 * Project     = Core
 *
 * Description = File-based logger implementation of ILogger.
 *****************************************************************************/

using System.IO;

namespace DependencyInversionLogger;

/// <summary>
/// Provides logging functionality by writing messages to a file.
/// </summary>
public class FileLogger : ILogger
{
    private readonly string _path;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileLogger"/> class.
    /// Ensures that the directory exists for the given file path.
    /// </summary>
    /// <param name="path">The file path where log messages will be written.</param>
    public FileLogger(string path)
    {
        var dir = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        _path = path;
    }

    /// <summary>
    /// Writes the specified message to the log file.
    /// </summary>
    /// <param name="message">The log message to write.</param>
    public void Log(string message)
    {
        File.AppendAllText(_path, $"[LOG] {message}{System.Environment.NewLine}");
    }
}

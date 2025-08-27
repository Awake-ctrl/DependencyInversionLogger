/******************************************************************************
 * Filename    = ConsoleLogger.cs
 *
 * Author      = Kallepally Sai Kiran
 *
 * Product     = DependencyInversionLogger
 * 
 * Project     = Core
 *
 * Description = Console-based logger implementation of ILogger.
 *****************************************************************************/

using System;

namespace DependencyInversionLogger;

/// <summary>
/// Provides logging functionality by writing messages to the console.
/// </summary>
public class ConsoleLogger : ILogger
{
    /// <summary>
    /// Writes the specified message to the console output.
    /// </summary>
    /// <param name="message">The log message to write.</param>
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}

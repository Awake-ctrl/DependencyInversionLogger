/******************************************************************************
 * Filename    = ILogger.cs
 *
 * Author      = Kallepally Sai Kiran
 *
 * Product     = DependencyInversionLogger
 * 
 * Project     = Core
 *
 * Description = Defines the contract for logging functionality.
 *****************************************************************************/

namespace DependencyInversionLogger;

/// <summary>
/// Defines the contract for a logger.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Logs the specified message.
    /// </summary>
    /// <param name="message">The log message to write.</param>
    void Log(string message);
}

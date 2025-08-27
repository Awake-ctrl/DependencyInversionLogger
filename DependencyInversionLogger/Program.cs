/******************************************************************************
 * Filename    = Program.cs
 *
 * Author      = Kallepally Sai Kiran
 *
 * Product     = DependencyInversionLogger
 * 
 * Project     = Core
 *
 * Description = Entry point of the application demonstrating the use of
 *               Dependency Inversion Principle with ConsoleLogger and FileLogger.
 *****************************************************************************/

namespace DependencyInversionLogger;

/// <summary>
/// Entry point for the Dependency Inversion Logger demo.
/// </summary>
class Program
{
    /// <summary>
    /// Main method demonstrating dependency inversion with two loggers.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    static void Main(string[] args)
    {
        // Example: use both loggers
        ILogger consoleLogger = new ConsoleLogger();
        ILogger fileLogger = new FileLogger("logs/app.log");

        var app1 = new Application(consoleLogger);
        app1.Run();

        var app2 = new Application(fileLogger);
        app2.Run();
    }
}

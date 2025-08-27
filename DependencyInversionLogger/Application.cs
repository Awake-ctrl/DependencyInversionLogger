/******************************************************************************
 * Filename    = Application.cs
 *
 * Author      = Kallepally Sai Kiran
 *
 * Product     = DependencyInversionLogger
 * 
 * Project     = Core
 *
 * Description = Defines the Application class that runs with a given logger.
 *****************************************************************************/

namespace DependencyInversionLogger;

/// <summary>
/// Represents an application that depends on an <see cref="ILogger"/>.
/// </summary>
public class Application
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Application"/> class.
    /// </summary>
    /// <param name="logger">The logger to be used by the application.</param>
    public Application(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Runs the application and logs its lifecycle.
    /// </summary>
    public void Run()
    {
        _logger.Log("Application started");
        // Business logic goes here
        _logger.Log("Application finished");
    }
}

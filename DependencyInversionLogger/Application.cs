namespace DependencyInversionLogger;
public class Application
{
    private readonly ILogger _logger;

    public Application(ILogger logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.Log("Application started");
        // Business logic goes here
        _logger.Log("Application finished");
    }
}

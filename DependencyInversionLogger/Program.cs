namespace DependencyInversionLogger;
class Program
{
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

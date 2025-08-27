using System.IO;

namespace DependencyInversionLogger;
public class FileLogger : ILogger
{
    private readonly string _path;

    public FileLogger(string path)
    {
        var dir = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        _path = path;
    }

    public void Log(string message)
    {
        File.AppendAllText(_path, $"[LOG] {message}{System.Environment.NewLine}");
    }
}

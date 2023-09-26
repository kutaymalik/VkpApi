namespace Vkp.Data.Services;

public class ConsoleLoggerService : ILoggerService
{
    public void Log(string message)
    {
        Console.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message}");
    }
}

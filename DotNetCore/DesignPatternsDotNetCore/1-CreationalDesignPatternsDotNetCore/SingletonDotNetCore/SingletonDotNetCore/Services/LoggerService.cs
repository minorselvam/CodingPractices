

namespace SingletonDotNetCore.Services
{
    public class LoggerService : Interfaces.ILogger
    {
        void Interfaces.ILogger.LogMessage(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}

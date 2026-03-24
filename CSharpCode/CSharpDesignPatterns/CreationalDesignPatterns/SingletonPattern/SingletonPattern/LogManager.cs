namespace SingletonPattern
{
    /*
     Explanation
        Lazy<T> ensures thread-safe lazy initialization without explicit locks, recommended for .NET 8.

        Logger is sealed to prevent inheritance, ensuring a single instance.

        The constructor is private, so no other class can instantiate Logger.

        Instance provides global access to the single Logger.

        This pattern is useful in logging in a distributed/global application, such as a shipping/logistics company, 
        ensuring a single logging instance handles all log entries consistently.
     */

    public sealed class Logger
    {       
        
        //private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
        
        //// Global access point to the single instance with thread-safety by Lazy<T>
        //public static Logger Instance => _instance.Value;
        
        
        ////Private constructor ensures no external instantiation
        //private Logger()
        //{
        //    // Simulate initialization, e.g., opening log file or setting up connection
        //}

        //public void Log(string message)
        //{
        //    // Log message to console or a file
        //    Console.WriteLine($"Log Entry: {message}");
        //}
    }
}

namespace MethodHidingOrShadowingEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!!!. Welcome to the Method Hiding Example.");

            // Case 1: Base class reference → calls BaseLogger.Log
            BaseLogger objBaseLogger = new BaseLogger();
            objBaseLogger.Log();
            // Output: BaseLogger Log Method call

            // Case 2: Derived class reference → calls FileLogger.Log
            FileLogger objFileLogger = new FileLogger();
            objFileLogger.Log();
            // Output: FileLogger Log Method call

            // Case 3: Base class reference pointing to derived object
            // Because of method hiding, this still calls BaseLogger.Log
            BaseLogger baseLogger = new FileLogger();
            baseLogger.Log();
            // Output: BaseLogger Log Method call
        }
    }
}

using System.Diagnostics;

namespace WithoutAsyncAndWithoutAwait
{
    internal class Program
    {
        //Declare methods as async but then call them without await
        static void Main(string[] args)
        {
            // Start stopwatch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Call Async Methods Without Await Helper");
            Console.WriteLine(System.Environment.NewLine);


            CallAsyncMethodsWithoutAwaitHelper objHelper = new CallAsyncMethodsWithoutAwaitHelper();
            var a = objHelper.MethodAPI();
            /*
             MethodAPI is async and returns Task < string >
             So a is not a string — it’s a Task<string> object.

            That means:

                You’re printing the task object, not the actual result.

                The delays (Task.Delay) are awaited inside the helper, but since you never await the method call in Main, 
                the program doesn’t wait for completion before printing.

                The stopwatch will show very small execution time because the tasks are scheduled but not awaited.

                🎯 Interview Takeaway
                    Mistake: Calling async methods without await → you get Task<string> instead of the actual result.

                    Fix: Make Main async and use await when calling async methods.

                    Why it matters: Without await, you don’t actually wait for the operation to finish, 
                    so your program prints incomplete results and execution time is misleading.
            */

            Console.WriteLine("Method 1 result: " + a);
            Console.WriteLine("Method 1 finished");
            Console.WriteLine(System.Environment.NewLine);


            var b = objHelper.MethodDB();
            Console.WriteLine("Method 2 result: " + b);
            Console.WriteLine("Method 2 finished");
            Console.WriteLine(System.Environment.NewLine);


            var c = objHelper.MethodFileSystem();
            Console.WriteLine("Method 3 result: " + c);
            Console.WriteLine("Method 3 finished");
            Console.WriteLine(System.Environment.NewLine);             

            Console.WriteLine("All methods and functions are finished");

            // Stop stopwatch
            stopwatch.Stop();
            Console.WriteLine("Total execution time: " + stopwatch.ElapsedMilliseconds + " ms");

        }
    }
}

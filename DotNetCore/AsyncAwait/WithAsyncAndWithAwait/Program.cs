using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WithAsyncAndWithAwait
{
    internal class Program
    {
        // 🔑 Async/Await in .NET 8: allows asynchronous code directly in Main
        static async Task Main(string[] args)
        {
            // 📌 Definition: A thread is the smallest unit of execution inside a process.
            // Each process can have multiple threads. In .NET, threads are managed by the Thread Pool.
            // In .NET, threads are managed by the Thread Pool, which reuses threads to avoid the overhead of creating new ones.

            // Thread ID before any async calls
            Console.WriteLine($"Main started on Thread {Environment.CurrentManagedThreadId}");

            // 🔑 Stopwatch for Performance Measurement
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("With Async And With Await");
            Console.WriteLine(System.Environment.NewLine);

            WithAsyncAndWithAwaitHelper objHelper = new WithAsyncAndWithAwaitHelper();

            Console.WriteLine("Method 1 called");
            // 🔑 Await pauses execution until task completes, without blocking the thread
            // 📌 After the delay finishes, the continuation may resume on the same thread 
            // or a different thread (depending on the SynchronizationContext).

            var a = await objHelper.MethodAPI();
            // 🔑 Thread IDs before and after await → may differ, showing that the thread was released and resumed later
            Console.WriteLine($"Continuation after MethodAPI on Thread {Environment.CurrentManagedThreadId}");
            Console.WriteLine("Method 1 result: " + a);
            Console.WriteLine("Method 1 finished");
            Console.WriteLine(System.Environment.NewLine);

            var b = await objHelper.MethodDB();
            // 🔑 Thread behavior: Continuations may resume on different threads, proving scalability
            Console.WriteLine($"Continuation after MethodDB on Thread {Environment.CurrentManagedThreadId}");
            Console.WriteLine("Method 2 result: " + b);
            Console.WriteLine("Method 2 finished");
            Console.WriteLine(System.Environment.NewLine);

            var c = await objHelper.MethodFileSystem();
            // 🔑 Thread behavior: Continuations may resume on different threads, proving scalability
            Console.WriteLine($"Continuation after MethodFileSystem on Thread {Environment.CurrentManagedThreadId}");
            Console.WriteLine("Method 3 result: " + c);
            Console.WriteLine("Method 3 finished");
            Console.WriteLine(System.Environment.NewLine);

            Console.WriteLine("All methods and functions are finished");

            stopwatch.Stop();
            Console.WriteLine("Total execution time: " + stopwatch.ElapsedMilliseconds + " ms");
            // 🔑 Thread ID at the end of Main — may differ from the start
            Console.WriteLine($"Main finished on Thread {Environment.CurrentManagedThreadId}");
        }
    }

    
}

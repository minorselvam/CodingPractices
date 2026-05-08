using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithAsyncAndWithAwait
{
    internal class WithAsyncAndWithAwaitHelper
    {
        public async Task<string> MethodAPI()
        {
            // Thread ID before await
            Console.WriteLine($"MethodAPI started on Thread {Environment.CurrentManagedThreadId}");
            await Task.Delay(5000); // 🔑 Simulates I/O-bound operation
            // 🔑 Thread IDs before and after await → may differ, showing thread release and continuation
            Console.WriteLine($"MethodAPI resumed after await on Thread {Environment.CurrentManagedThreadId}");
            return "MethodAPI Result";
        }

        public async Task<string> MethodDB()
        {
            Console.WriteLine($"MethodDB started on Thread {Environment.CurrentManagedThreadId}");
            await Task.Delay(6000); // 🔑 Simulates DB query delay
            // 🔑 Continuation may resume on a different thread
            Console.WriteLine($"MethodDB resumed after await on Thread {Environment.CurrentManagedThreadId}");
            return "MethodDB Result";
        }

        public async Task<string> MethodFileSystem()
        {
            Console.WriteLine($"MethodFileSystem started on Thread {Environment.CurrentManagedThreadId}");
            await Task.Delay(8000); // 🔑 Simulates file system I/O delay
            // 🔑 Continuation may resume on a different thread
            Console.WriteLine($"MethodFileSystem resumed after await on Thread {Environment.CurrentManagedThreadId}");
            return "MethodFileSystem Result";
        }
    }
}

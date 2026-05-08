using System.Diagnostics;

namespace WithoutAsyncAndWithoutAwait
{
    internal class Program
    {
        ////Without Async and Without Await
        static void Main(string[] args)
        {
            // Start stopwatch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Without Async And Without Await Helper");
            Console.WriteLine(System.Environment.NewLine);


            WithoutAsyncAndWithoutAwaitHelper objHelper = new WithoutAsyncAndWithoutAwaitHelper();
            var a = objHelper.MethodAPI();
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


            ////Checking the variable value in the console without Await
            //var result = objHelper.GetNumber();
            //Console.WriteLine("Result value without using the await: " + result);

            Console.WriteLine("All methods and functions are finished");

            // Stop stopwatch
            stopwatch.Stop();
            Console.WriteLine("Total execution time: " + stopwatch.ElapsedMilliseconds + " ms");

        }
    }
}

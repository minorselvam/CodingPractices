using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {

        //With Async and Await
        static async Task Main(string[] args)
        {
            // Start stopwatch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Hello, World!");

            Helper objHelper = new Helper();
            Console.WriteLine("Method 1 called");
            var a = await objHelper.MethodAPI();
            Console.WriteLine("Waiting for Method 1 reult: first test message");
            Console.WriteLine("Waiting for Method 1 reult: second test message");

            Console.WriteLine("Method 1 result: " + a);
            Console.WriteLine("Method 1 finished");
            Console.WriteLine(System.Environment.NewLine);

            var b = await objHelper.MethodDB();
            Console.WriteLine("Method 2 result: " + b);
            Console.WriteLine("Method 2 finished");
            Console.WriteLine(System.Environment.NewLine);


            var c = await objHelper.MethodFileSystem();
            Console.WriteLine("Method 3 result: " + c);
            Console.WriteLine("Method 3 finished");
            Console.WriteLine(System.Environment.NewLine);


            Console.WriteLine("All methods and functions are finished");

            // Stop stopwatch
            stopwatch.Stop();
            Console.WriteLine("Total execution time: " + stopwatch.ElapsedMilliseconds + " ms");
        }



        //Without Async and Await
        //static void Main(string[] args)
        //{
        //    // Start stopwatch
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();

        //    Console.WriteLine("Hello, World!");

        //    Helper objHelper = new Helper();
        //    var a = objHelper.MethodAPI();
        //    Console.WriteLine("Method 1 result: " + a);
        //    Console.WriteLine("Method 1 finished");
        //    Console.WriteLine(System.Environment.NewLine);


        //    var b = objHelper.MethodDB();
        //    Console.WriteLine("Method 2 result: " + b);
        //    Console.WriteLine("Method 2 finished");
        //    Console.WriteLine(System.Environment.NewLine);


        //    var c = objHelper.MethodFileSystem();
        //    Console.WriteLine("Method 3 result: " + c);
        //    Console.WriteLine("Method 3 finished");
        //    Console.WriteLine(System.Environment.NewLine);


        //    ////Checking the variable value in the console without Await
        //    //var result = objHelper.GetNumber();
        //    //Console.WriteLine("Result value without using the await: " + result);

        //    Console.WriteLine("All methods and functions are finished");

        //    // Stop stopwatch
        //    stopwatch.Stop();
        //    Console.WriteLine("Total execution time: " + stopwatch.ElapsedMilliseconds + " ms");

        //}

    }
}

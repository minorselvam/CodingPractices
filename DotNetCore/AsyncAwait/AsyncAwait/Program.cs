using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        
        //With Async and Await
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Helper objHelper = new Helper();
            Console.WriteLine("Method 1 called");
            var a = await objHelper.MethodAPI();
            Console.WriteLine("Waiting for Method 1 reult: first test message");
            Console.WriteLine("Waiting for Method 1 reult: second test message");

            Console.WriteLine("Method 1 result: " + a);
            Console.WriteLine("Method 1 finished");

            var b = await objHelper.MethodDB();
            Console.WriteLine("Method 2 result: " + b);
            Console.WriteLine("Method 2 finished");

            var c = await objHelper.MethodFileSystem();
            Console.WriteLine("Method 3 result: " + c);
            Console.WriteLine("Method 3 finished");

            Console.WriteLine("All methods and functions are finished");
        }
         

        /*
        //Without Async and Await
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Helper objHelper = new Helper();
            var a = objHelper.MethodAPI();
            Console.WriteLine("Method 1 result: " + a);
            Console.WriteLine("Method 1 finished");

            var b = objHelper.MethodDB();
            Console.WriteLine("Method 2 result: " + b);
            Console.WriteLine("Method 2 finished");

            var c = objHelper.MethodFileSystem();
            Console.WriteLine("Method 3 result: " + c);
            Console.WriteLine("Method 3 finished");

            Console.WriteLine("All methods and functions are finished");
        }
        */
    }
}

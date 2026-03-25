using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Parallel Execution Started ===");
        Stopwatch stopwatch = Stopwatch.StartNew();

        Parallel.For(1, 10000000, i =>
        {
            if (IsPrime(i))
            {
                // Heavy work for prime numbers
                // Console.WriteLine($"Prime: {i}");
            }
        });

        stopwatch.Stop();
        Console.WriteLine("=== Parallel Execution Completed ===");
        Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0) return false;
        return true;
    }
}

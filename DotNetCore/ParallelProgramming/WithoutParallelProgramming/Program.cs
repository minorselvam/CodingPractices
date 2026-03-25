using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Sequential Execution Started ===");
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 1; i <= 10000000; i++)
        {
            if (IsPrime(i))
            {
                // Heavy work for prime numbers
                // Console.WriteLine($"Prime: {i}");
            }
        }

        stopwatch.Stop();
        Console.WriteLine("=== Sequential Execution Completed ===");
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

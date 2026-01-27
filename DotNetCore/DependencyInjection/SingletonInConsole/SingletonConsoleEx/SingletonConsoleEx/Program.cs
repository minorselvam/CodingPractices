//namespace SingletonConsoleEx
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//        }
//    }
//}


using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public interface ISampleService { }

public class SampleService : ISampleService { }

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ISampleService, SampleService>();
        var provider = services.BuildServiceProvider();

        // Resolve the service multiple times, possibly in parallel
        Parallel.For(0, 5, i =>
        {
            var instance = provider.GetRequiredService<ISampleService>();
            Console.WriteLine($"Instance {i}: HashCode = {instance.GetHashCode()}");
        });
    }
}

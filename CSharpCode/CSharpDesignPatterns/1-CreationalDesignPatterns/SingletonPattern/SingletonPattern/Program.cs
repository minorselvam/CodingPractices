//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using SingletonPattern;
namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*
            //Accessing the Singleton Instance
            SingletonExample S1 = SingletonExample.Instance;
            SingletonExample S2 = SingletonExample.Instance;

            S1.PrintDetails();

            // Both references point to the same instance
            Console.WriteLine("Is object.ReferenceEquals: " + object.ReferenceEquals(S1, S2)); // Output: True
            */


            //Logger Instance Checking
            Logger.Instance.Log("Shipment #1234 created");
            Logger.Instance.Log("Shipment #1234 dispatched");

            //Checking both the Instances are same or not
            Console.WriteLine("Is Logger Object ReferenceEquals: " + object.ReferenceEquals(Logger.Instance, Logger.Instance));
        }
    }
}

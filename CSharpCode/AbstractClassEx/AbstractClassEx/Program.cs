namespace AbstractClassEx
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            MotorBike bike1 = new SprtsBike();
            MotorBike bike2 = new MountainBike();

            bike1.Start();
            bike1.Brake();

            bike2.Start();
            bike2.Brake();
        }
    }
}

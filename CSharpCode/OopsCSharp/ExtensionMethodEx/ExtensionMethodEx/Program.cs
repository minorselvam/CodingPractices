namespace ExtensionMethodEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!!!....Welcome to Extension Method Example....");

            string sentence = "C# extension methods are very useful";
            int count = sentence.WordCount();
            Console.WriteLine("The word count from the given sentence is " + count);
        }
    }
}

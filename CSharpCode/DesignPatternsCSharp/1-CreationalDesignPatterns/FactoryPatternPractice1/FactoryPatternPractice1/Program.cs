namespace FactoryPatternPractice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console code usage
            Console.WriteLine("Select the type of report you want to generate (sales, inventory): ");
            string reportType = Console.ReadLine();
            //Console.WriteLine("Hello, World!");
            IReportGenerator reportGenerator = FactoryPatternExample.CreateReport(reportType);
            reportGenerator.GenerateReport();

        }
    }
}

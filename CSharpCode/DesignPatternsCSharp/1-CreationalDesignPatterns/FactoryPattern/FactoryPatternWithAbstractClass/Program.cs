namespace FactoryPatternWithAbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the type of report you want to generate (sales, inventory, hr, loan): ");
            string reportType = Console.ReadLine();

            try
            {
                ReportGenerator reportGenerator = FactoryPatternWithAbstractExample.CreateReport(reportType);
                reportGenerator.GenerateReport();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using FactoryPattern;
namespace MyApp{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // 4. Client Code (Usage)
            Console.WriteLine("Select the type of report you want to generate (sales or inventory or hr or loan?): ");
            string reportType = Console.ReadLine();

            try
            {
                IReportGenerator reportGenerator = FactoryPatternExample.CreateReport(reportType);
                reportGenerator.GenerateReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

namespace WithoutFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the type of report you want to generate (sales, inventory, hr, loan):");
            string reportType = Console.ReadLine();

            IReportGenerator reportGenerator;

            if (reportType.Equals("sales", StringComparison.OrdinalIgnoreCase))
            {
                reportGenerator = new SalesReport();
            }
            else if (reportType.Equals("inventory", StringComparison.OrdinalIgnoreCase))
            {
                reportGenerator = new InventoryReport();
            }
            else if (reportType.Equals("hr", StringComparison.OrdinalIgnoreCase))
            {
                reportGenerator = new HRReport();
            }
            else if (reportType.Equals("loan", StringComparison.OrdinalIgnoreCase))
            {
                reportGenerator = new LoanReport();
            }
            else
            {
                Console.WriteLine("Invalid report type");
                return;
            }

            reportGenerator.GenerateReport();
        }
    }
}

using KeyedDepncyInjcnPatn.Interfaces;

namespace KeyedDepncyInjcnPatn.Processors
{
    //Another concrete implementation. Handles PayPal-specific logic.
    public class PaypalProcessor : IReportGenerator
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Paypal process the amount " + amount);
        }
    }
}

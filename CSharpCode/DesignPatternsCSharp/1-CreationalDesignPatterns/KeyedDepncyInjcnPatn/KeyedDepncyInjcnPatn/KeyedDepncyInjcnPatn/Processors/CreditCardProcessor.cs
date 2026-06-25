using KeyedDepncyInjcnPatn.Interfaces;

namespace KeyedDepncyInjcnPatn.Processors
{
    //A concrete implementation of IReportGenerator. Handles CreditCard-specific logic.
    public class CreditCardProcessor: IReportGenerator
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Credit card process the amount " + amount);
        }
    }
}

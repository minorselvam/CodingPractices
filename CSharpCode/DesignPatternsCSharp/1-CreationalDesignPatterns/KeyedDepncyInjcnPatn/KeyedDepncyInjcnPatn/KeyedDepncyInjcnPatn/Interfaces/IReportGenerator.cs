namespace KeyedDepncyInjcnPatn.Interfaces
{
    //This is the contract. Both CreditCardProcessor and PaypalProcessor must implement this method.
    //It ensures consistency across implementations.
    public interface IReportGenerator
    {
        public void ProcessPayment(decimal amount);
    }
}

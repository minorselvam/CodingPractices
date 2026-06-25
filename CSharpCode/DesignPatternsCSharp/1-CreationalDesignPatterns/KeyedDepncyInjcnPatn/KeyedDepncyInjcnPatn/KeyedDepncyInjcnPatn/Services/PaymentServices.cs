using KeyedDepncyInjcnPatn.Interfaces;

namespace KeyedDepncyInjcnPatn.Services
{
    //This is the business logic layer. It uses GetKeyedService to dynamically pick the
    //correct processor based on the client’s input (paymentType). No factory or manual filtering needed.
    public class PaymentServices
    {
        private readonly IServiceProvider _serviceProvider;
        public PaymentServices(IServiceProvider serviceProvider) 
        { 
            _serviceProvider = serviceProvider;
        }

       public void Execute(string paymentType, decimal amount)
        {
            // Resolve the correct processor dynamically by key
            var processor = _serviceProvider.GetKeyedService<IReportGenerator>(paymentType);
            processor.ProcessPayment(amount); // Execute chosen processor
        }
    }
}

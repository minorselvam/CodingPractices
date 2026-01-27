using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
    class CreditCardPayment : IPaymentMode
    {
        public void MakePayment()
        {
            Console.WriteLine("Credit card payment mode activated...");
        }
    }
}

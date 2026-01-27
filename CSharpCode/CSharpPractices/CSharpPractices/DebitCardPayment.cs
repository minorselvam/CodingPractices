using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
    class DebitCardPayment : IPaymentMode
    {
        public void MakePayment()
        {
            Console.WriteLine("Debit card payment mode activated...");
        }
    }
}

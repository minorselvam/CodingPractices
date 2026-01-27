using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
    class GooglePay : IPaymentMode
    {
        public void MakePayment()
        {
            Console.WriteLine("Google pay mode activated...");
        }
    }
}

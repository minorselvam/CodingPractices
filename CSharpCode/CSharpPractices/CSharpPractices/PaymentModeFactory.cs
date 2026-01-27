using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
    public enum Mode
    {
        CreditCard,
        DebitCard,
        GooglePay
    }

    class PaymentModeFactory
    {
        
            public static IPaymentMode Create(Mode mode)
            {
                if(mode == Mode.CreditCard)
                {
                    return new CreditCardPayment();
                }
                else if (mode == Mode.DebitCard)
                { 
                    return new DebitCardPayment(); 
                }
                else
                 return new GooglePay();
            }
    }
}

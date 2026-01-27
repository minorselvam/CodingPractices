using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
    class PaymentManager
    {


        //private readonly CreditCardPayment creditCard;
        //private readonly DebitCardPayment debitdCard;
        //private readonly GooglePay googlePay;

        //public PaymentManager(CreditCardPayment crdtCard, DebitCardPayment dbtdCard, GooglePay gPay) 
        //{
        //    this.creditCard = crdtCard;
        //    this.debitdCard = dbtdCard;
        //    this.googlePay = gPay;
        //}

        //public void ManagePayment()
        //{
        //    creditCard.MakePayment();
        //    debitdCard.MakePayment();
        //    googlePay.MakePayment();
        //}

        private readonly IPaymentMode paymentMode;
        public PaymentManager(IPaymentMode payMode)
        {
            this.paymentMode = payMode;
        }

        public void ManagePayment()
        {
            paymentMode.MakePayment();
        }




    }
}

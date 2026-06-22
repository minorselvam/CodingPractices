using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateAccess
{
    public class BankAccount
    {
        private decimal accountBalance;

        public BankAccount(decimal amount)
        {
            accountBalance = amount; //private members are only accessible inside that class itself
            Console.WriteLine("Initial Balance: " + accountBalance);
        }

        public void DeductAccountBalance(decimal amount)
        {
            accountBalance = accountBalance - amount;
            Console.WriteLine("Current Balance: " + accountBalance);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedPrivateClassEx
{
    public class BankAccount
    {
        private decimal accountBalance;

        public BankAccount(decimal amount)
        {
            accountBalance = amount;
            transactions.Add(new Transaction(accountBalance));
        }


        public void DeductBalance(decimal amount) 
        {
            accountBalance = accountBalance - amount;
            Console.WriteLine("Amount is deducted and current balance is " + accountBalance);
            transactions.Add(new Transaction(accountBalance));
        }

        private class Transaction
        {
            public decimal amount { get; }
            public DateTime transactionDate { get; }

            public Transaction(decimal inputAmount)
            {
                amount = inputAmount;
                transactionDate = DateTime.Now;
            }
        }

        private List<Transaction> transactions = new List<Transaction>();

        public void PrintStatement()
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine("Transaction amount " + transaction.amount + " on the date " + transaction.transactionDate);
            }
        }

    }
}

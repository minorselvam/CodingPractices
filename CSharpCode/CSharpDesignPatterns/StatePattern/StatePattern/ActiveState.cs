using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StatePattern.Program;

namespace StatePattern
{
    public class ActiveState : IAccountState
    {

        public void Deposit(BankAccount account, decimal amount)
        {
            account.Balance += amount;
            Console.WriteLine($"Deposited {amount}. Balance: {account.Balance}");
        }

        public void Withdraw(BankAccount account, decimal amount)
        {
            if (account.Balance - amount < 0)
            {
                account.Balance -= amount;
                Console.WriteLine($"Overdrawn! Balance: {account.Balance}");
                account.SetState(new OverDrawnState());
            }
            else
            {
                account.Balance -= amount;
                Console.WriteLine($"Withdrew {amount}. Balance: {account.Balance}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StatePattern.Program;

namespace StatePattern
{
    public class OverDrawnState : IAccountState
    {
        void IAccountState.Deposit(BankAccount account, decimal amount)
        {
            account.Balance += amount;
            Console.WriteLine($"Deposited {amount}. Balance: {account.Balance}");

            if (account.Balance >= 0)
            {
                account.SetState(new ActiveState());
            }
        }

        void IAccountState.Withdraw(BankAccount account, decimal amount)
        {
            Console.WriteLine("Cannot withdraw. Account is overdrawn!");
        }
    }
}

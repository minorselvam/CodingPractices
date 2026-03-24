using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StatePattern.Program;

namespace StatePattern
{
    public class ClosedState : IAccountState
    {
        void IAccountState.Deposit(BankAccount account, decimal amount)
        {
            Console.WriteLine("Account is closed. Cannot deposit.");
        }

        void IAccountState.Withdraw(BankAccount account, decimal amount)
        {
            Console.WriteLine("Account is closed. Cannot withdraw.");
        }
    }
}

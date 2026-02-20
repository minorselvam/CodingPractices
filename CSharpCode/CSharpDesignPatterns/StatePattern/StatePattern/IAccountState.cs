using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StatePattern.Program;

namespace StatePattern
{
    // State Interface
    public interface IAccountState
    {
        void Deposit(BankAccount account, decimal amount);
        void Withdraw(BankAccount account, decimal amount);
    }
}

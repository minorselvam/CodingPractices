using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        private IAccountState _state;

        public BankAccount()
        {
            _state = new ActiveState();
        }

        public void SetState(IAccountState state)
        {
            _state = state;
            Console.WriteLine($"State changed to: {state.GetType().Name}");
        }

        public void Deposit(decimal amount) => _state.Deposit(this, amount);
        public void Withdraw(decimal amount) => _state.Withdraw(this, amount);

        public void CloseAccount() => SetState(new ClosedState());
    }
}

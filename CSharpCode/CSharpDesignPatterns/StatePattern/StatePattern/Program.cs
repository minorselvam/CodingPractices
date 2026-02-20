using static StatePattern.Program;

namespace StatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            account.Deposit(100);
            account.Withdraw(50);

            account.Withdraw(70); // Goes overdrawn
            account.Deposit(30); // Back to active

            account.CloseAccount();

            account.Deposit(20); // Not allowed
        }
    }
     
}

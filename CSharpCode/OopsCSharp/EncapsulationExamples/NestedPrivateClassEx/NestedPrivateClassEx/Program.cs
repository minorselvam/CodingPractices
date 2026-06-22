namespace NestedPrivateClassEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!!!... Welcome to the Nested Private Class Example...!!!!");
            BankAccount objBankAccount = new BankAccount(4500);
            objBankAccount.DeductBalance(2000);
            objBankAccount.PrintStatement();

            // ❌ Not allowed: The class Transaction is private
            // BankAccount.Transaction t = new BankAccount.Transaction(200);
        }
    }
}

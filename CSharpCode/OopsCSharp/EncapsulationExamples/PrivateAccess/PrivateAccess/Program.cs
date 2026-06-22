namespace PrivateAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!!!. Welcome to Private access modifier examples...");
            BankAccount objBankAccount = new BankAccount(500); //Passing value to constrcutor to update private member value in a class.
            objBankAccount.DeductAccountBalance(200);

            //objBankAccount.accountBalance //Compilation Error.
            //Outside code cannot directly touch them — it must go through the class’s public methods or public properties
            //Error- 'BankAccount.accountBalance' is inaccessible due to its protection level
        }
    }
}

//private members are only accessible inside that class itself

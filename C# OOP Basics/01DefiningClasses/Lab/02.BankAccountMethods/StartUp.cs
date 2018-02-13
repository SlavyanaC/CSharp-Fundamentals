using System;

class StartUp
{
    static void Main(string[] args)
    {
        BankAccount acc = new BankAccount();

        acc.Id = 1;
        acc.Deposit(15);
        acc.Withdraw(10);

        Console.WriteLine(acc);
    }
}


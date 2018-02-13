using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var splitCommand = command.Split();
            var accountId = int.Parse(splitCommand[1]);
            switch (splitCommand[0])
            {
                case "Create":
                    if (accounts.ContainsKey(accountId))
                        Console.WriteLine("Account already exists");
                    else
                    {
                        var account = new BankAccount();
                        accounts.Add(accountId, new BankAccount { Id = accountId });
                    }
                    break;
                case "Deposit":
                    if (ValidateAccountAexists(accountId, accounts))
                    {
                        int sum = int.Parse(splitCommand[2]);
                        accounts[accountId].Deposit(sum);
                    }
                    break;
                case "Withdraw":
                    if (ValidateAccountAexists(accountId, accounts))
                    {
                        int sum = int.Parse(splitCommand[2]);
                        accounts[accountId].Withdraw(sum);
                    }
                    break;
                case "Print":
                    if (ValidateAccountAexists(accountId, accounts))
                    {
                        Console.WriteLine(accounts[accountId]);
                    }
                    break;
            }
        }
    }

    static bool ValidateAccountAexists(int accountId, Dictionary<int, BankAccount> accounts)
    {
        if (accounts.ContainsKey(accountId))
            return true;

        Console.WriteLine("Account does not exist");
        return false;
    }
}
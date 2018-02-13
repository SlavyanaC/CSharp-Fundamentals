using System;
using System.Collections.Generic;
using System.Text;

public class BankAccount
{
    private int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private decimal balance;
    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (balance < amount)
            Console.WriteLine("Insufficient balance");
        else
            this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:f2}";
    }
}

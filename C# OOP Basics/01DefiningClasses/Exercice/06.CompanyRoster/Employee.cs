using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    private string name;
    private int age;
    private decimal salary;
    private string position;
    private string email;

    public Employee()
    {
        this.Email = "n/a";
        this.Age = -1;
    }

    public Employee(string name, string position, decimal salary, int age = -1, string email = "n/a")
    {
        this.Name = name;
        this.Position = position;
        this.Salary = salary;
        this.Age = age;
        this.Email = email;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}

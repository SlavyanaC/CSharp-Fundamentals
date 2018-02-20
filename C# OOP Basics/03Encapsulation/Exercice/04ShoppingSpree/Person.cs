using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    public List<Product> Bag { get; set; }

    public Person()
    {
        this.Bag = new List<Product>();
    }

    public Person(string name, decimal money)
        : this()
    {
        this.Name = name;
        this.Money = money;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public void BuyProduct(Product product)
    {

        this.Money -= product.Cost;
    }
}

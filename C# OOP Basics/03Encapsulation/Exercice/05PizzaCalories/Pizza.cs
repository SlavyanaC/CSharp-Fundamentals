using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Pizza
{
    private const int minNameLength = 1;
    private const int maxNameLength = 15;

    private string name;

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }
    public Pizza(string name)
        : this()
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < minNameLength || value.Length > maxNameLength)
            {
                throw new ArgumentException($"Pizza name should be between {minNameLength} and {maxNameLength} symbols.");
            }
            name = value;
        }
    }

    public Dough Dough { get; set; }

    public List<Topping> Toppings { get; set; }

    public decimal Calories { get; set; }

    public decimal CalculateCalories()
    {
        decimal calories = this.Dough.CalculateCalories() + this.Toppings.Sum(t => t.CalculateCalories());
        return calories;
    }
}

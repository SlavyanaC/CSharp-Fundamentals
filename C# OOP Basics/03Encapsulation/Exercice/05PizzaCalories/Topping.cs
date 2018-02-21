using System;
using System.Linq;

class Topping
{
    private readonly string[] ToppingTypes = { "meat", "veggies", "cheese", "sauce" };
    private const decimal MeatModifier = 1.2m;
    private const decimal VeggiesModifier = 0.8m;
    private const decimal CheeseModifier = 1.1m;
    private const decimal SauceModifier = 0.9m;

    private const int MinWeight = 1;
    private const int MaxWeight = 50; 

    private string type;
    private decimal weight;

    public Topping(string type, decimal weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get { return type; }
        set
        {
            if (!ToppingTypes.Contains(value.ToLower()) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public decimal Weight
    {
        get { return weight; }
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException($"{this.type} weight should be in the range [{MinWeight}..{MaxWeight}].");
            }
            weight = value;
        }
    }

    public decimal CalculateCalories()
    {
        decimal toppingModifier = 0.0m;

        switch (this.type.ToLower())
        {
            case "meat":
                toppingModifier = MeatModifier;
                break;
            case "veggies":
                toppingModifier = VeggiesModifier;
                break;
            case "cheese":
                toppingModifier = CheeseModifier;
                break;
            case "sauce":
                toppingModifier = SauceModifier;
                break;
        }

        decimal calories = 2 * toppingModifier * this.Weight;
        return calories;
    }
}

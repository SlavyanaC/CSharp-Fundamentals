using System;
using System.Linq;

public class Dough
{
    private readonly string[] DoughTypes = new string[] { "white", "wholegrain" };
    private const decimal WhiteModifier = 1.5m;
    private const decimal WholegrainModifier = 1.0m;

    private readonly string[] BakingTechnique = new string[] { "crispy", "chewy", "homemade" };
    private const decimal CrispyModifier = 0.9m;
    private const decimal ChewyModifier = 1.1m;
    private const decimal HomemadeModifier = 1.0m;

    private const int MinWeight = 1;
    private const int MaxWeight = 200;

    private string type;
    private string technique;
    private decimal weight;

    public Dough(string type, string technique, decimal weight)
    {
        this.Type = type;
        this.Technique = technique;
        this.Weight = weight;
    }

    public string Type
    {
        get { return type; }
        set
        {
            if (!DoughTypes.Contains(value.ToLower()) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            type = value;
        }
    }

    public string Technique
    {
        get { return technique; }
        set
        {
            if (!BakingTechnique.Contains(value.ToLower()) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            technique = value;
        }
    }

    public decimal Weight
    {
        get { return weight; }
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
            }
            weight = value;
        }
    }

    public decimal CalculateCalories()
    {
        decimal doughTypeModifier = 0.0m;
        decimal bakingTechModifier = 0.0m;
        switch (this.type.ToLower())
        {
            case "white":
                doughTypeModifier = WhiteModifier;
                break;
            case "wholegrain":
                doughTypeModifier = WholegrainModifier;
                break;
            default:
                throw new ArgumentException("Invalid type of dough.");
        }

        switch (this.technique.ToLower())
        {
            case "crispy":
                bakingTechModifier = CrispyModifier;
                break;
            case "chewy":
                bakingTechModifier = ChewyModifier;
                break;
            case "homemade":
                bakingTechModifier = HomemadeModifier;
                break;
            default:
                throw new ArgumentException("Invalid type of dough.");
        }

        decimal calories = (2 * this.Weight) * doughTypeModifier * bakingTechModifier;
        return calories;
    }
}

using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.Horsepower += this.Horsepower * 50 / 100;
        this.Suspension -= this.Suspension * 25 / 100;
    }

    public List<string> AddOns { get; set; }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(base.ToString());
        if (this.AddOns.Count > 0)
        {
            builder.AppendLine($"Add-ons: " + string.Join(", ", this.AddOns));
        }
        else
        {
            builder.AppendLine("Add-ons: None");
        }

        return builder.ToString().TrimEnd();
    }
}

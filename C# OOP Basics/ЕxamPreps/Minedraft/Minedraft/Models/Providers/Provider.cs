using System;
using System.Text;

public abstract class Provider
{
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get => this.id;
        protected set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.Id)}");
            }

            this.id = value;
        }
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0.0 || value >= 10000.0)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var typeName = GetType().Name.Equals("SolarProvider") ? "Solar" : "Pressure";

        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{typeName} Provider - {this.Id}");
        builder.AppendLine($"Energy Output: {(int)this.EnergyOutput}");

        return builder.ToString().TrimEnd();
    }
}

using System;
using System.Text;

public abstract class Provider : Worker
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
         : base(id)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
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

    public string Name => this.GetType().Name.Equals("PressureProvider") ? "Pressure" : "Solar";

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{this.Name} Provider - {this.Id}");
        builder.AppendLine($"Energy Output: {(int)this.EnergyOutput}");

        return builder.ToString().TrimEnd();
    }
}

using System;

public abstract class Provider : IProvider
{
    private const double InitialDurability = 1000;
    private const double DurabilityDailyLoss = 100;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DurabilityDailyLoss;
        if (this.Durability < 0)
        {
            throw new Exception();
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double value)
    {
        this.Durability += value;
    }
}
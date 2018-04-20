using System;

public abstract class Harvester : IHarvester
{
    private const double InitialDurability = 1000;
    private const double DurabilityModeLoss = 100;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set => this.oreOutput = value;
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set => this.energyRequirement = value;
    }

    public virtual double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DurabilityModeLoss;
        if (this.Durability < 0)
        {
            throw new Exception();
        }
    }

    public double Produce()
    {
        return this.OreOutput;
    }
}
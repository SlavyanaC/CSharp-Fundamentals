using System;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        base.EnergyRequirement /= this.SonicFactor;
    }

    public int SonicFactor
    {
        get=>this.sonicFactor;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.SonicFactor)}");
            }
            this.sonicFactor = value;
        }
    }
}

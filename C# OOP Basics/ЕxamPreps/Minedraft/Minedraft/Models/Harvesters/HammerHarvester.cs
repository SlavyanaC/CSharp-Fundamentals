public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        base.OreOutput += 2 * oreOutput;
        base.EnergyRequirement = energyRequirement + energyRequirement;
    }
}

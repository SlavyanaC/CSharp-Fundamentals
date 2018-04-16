public class SonicHarvester : Harvester
{
    private const int DurabilityLoss = 300;
    private const int EnergyRequirementDivider = 2;

    public SonicHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.Durability -= DurabilityLoss;
        this.EnergyRequirement /= EnergyRequirementDivider;
    }
}
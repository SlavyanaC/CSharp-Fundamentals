public class PressureProvider : Provider
{
    private const double EnergyOutputMultiply = 2;
    private const double DurabilityDecrease = 300;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.EnergyOutput *= EnergyOutputMultiply;
        this.Durability -= DurabilityDecrease;
    }
}

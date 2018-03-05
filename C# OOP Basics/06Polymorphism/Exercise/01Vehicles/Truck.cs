public class Truck : Vehicle
{
    private const double AccConsumption = 1.6;
    private const double HoleLossPercentage = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption + AccConsumption;
    }

    public override void Refuel(double fuel)
    {
        base.Refuel(fuel * HoleLossPercentage);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}

using System;

public class Truck : Vehicle
{
    private const double AccConsumption = 1.6;
    private const double HoleLossPercentage = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption + AccConsumption;
        this.TankCapacity = tankCapacity;
    }

    public override void Refuel(double fuel)
    {
        try
        {
            base.Refuel(fuel * HoleLossPercentage);
        }
        catch (ArgumentException)
        {
            base.Refuel(fuel);
        }
    }
}

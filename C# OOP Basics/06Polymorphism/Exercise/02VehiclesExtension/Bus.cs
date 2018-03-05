public class Bus : Vehicle
{
    private const double AccConsumption = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public override bool CanBeDriven(double distance, bool isAccActive)
    {
        double fuelNeeded = 0.0;
        if (isAccActive)
        {
            fuelNeeded = distance * (this.FuelConsumption + AccConsumption);
        }
        else
        {
            fuelNeeded = distance * this.FuelConsumption;
        }

        if (this.FuelQuantity >= fuelNeeded)
        {
            this.FuelQuantity -= fuelNeeded;
            return true;
        }

        return false;
    }
}

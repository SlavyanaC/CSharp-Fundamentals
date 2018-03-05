public class Car : Vehicle
{
    public const double AccConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption + AccConsumption;
        this.TankCapacity = tankCapacity;
    }
}

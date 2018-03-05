using System;

public abstract class Vehicle
{
    public double FuelQuantity { get; set; }

    public double FuelConsumption { get; set; }

    public double TankCapacity { get; set; }

    public virtual void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        else if (this.FuelQuantity + fuel >= this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += fuel;
        }
    }

    public string TryDrive(double distance, bool isActive)
    {
        if (this.CanBeDriven(distance, true))
        {
            return $"{this.GetType().Name} travelled {distance} km";
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
    }

    public string TryDrive(double distance)
    {
       return this.TryDrive(distance, true);
    }

    public virtual bool CanBeDriven(double distance, bool isAccActive)
    {
        double fuelNeeded = this.FuelConsumption * distance;
        if (fuelNeeded <= this.FuelQuantity)
        {
            this.FuelQuantity -= fuelNeeded;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}

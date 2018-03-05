using System;

public abstract class Vehicle
{
    public double FuelQuantity { get; set; }

    public double FuelConsumption { get; set; }

    public virtual void Refuel(double fuel)
    {
        this.FuelQuantity += fuel;
    }


    public string TryDrive(double distance)
    {
        if (this.CanBeDriven(distance))
        {
            return $"{this.GetType().Name} travelled {distance} km";
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
    }

    public virtual bool CanBeDriven(double distance)
    {
        double fuelNeeded = this.FuelConsumption * distance;
        if (fuelNeeded <= this.FuelQuantity)
        {
            this.FuelQuantity -= fuelNeeded;
            return true;
        }

        return false;
    }
}

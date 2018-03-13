using System;

public class Car
{
    private const int MAXIMUM_TANK_CAPACITY = 160;

    private double fuelAmount;
    private Tyre tyre;

    public Car(int horsepower, double fuelAmount, Tyre tyre)
    {
        this.Horsepower = horsepower;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Horsepower { get; private set; }

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            this.fuelAmount = value > MAXIMUM_TANK_CAPACITY ? MAXIMUM_TANK_CAPACITY : value;
        }
    }

    public Tyre Tyre
    {
        get { return tyre; }
        private set { tyre = value; }
    }

    public void ChangeTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }

    public void Refuel(double newFuelAmount)
    {
        this.FuelAmount += newFuelAmount;
    }

    public void ReduceFuelAmount(int trackLenght, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLenght * fuelConsumptionPerKm;
        if (this.FuelAmount > MAXIMUM_TANK_CAPACITY)
        {
            this.FuelAmount = MAXIMUM_TANK_CAPACITY;
        }
    }
}

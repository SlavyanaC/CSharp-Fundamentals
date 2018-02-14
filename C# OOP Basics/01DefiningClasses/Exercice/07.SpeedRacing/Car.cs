using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumption;
    private decimal traveledDistance;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public decimal FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public decimal FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public decimal TraveledDistance
    {
        get { return this.traveledDistance; }
        set { traveledDistance = value; }
    }

    public Car(string model, decimal fuelAmount, decimal fuelConsumption)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
        this.traveledDistance = 0;
    }

    public void Drive(int kilometers)
    {
        if (kilometers <= this.fuelAmount / this.fuelConsumption)
        {
            this.traveledDistance += kilometers;
            this.fuelAmount -= this.fuelConsumption * kilometers;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

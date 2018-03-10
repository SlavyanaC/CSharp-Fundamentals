using System;
using System.Collections.Generic;
using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsePower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand
    {
        get { return brand; }
        protected set { brand = value; }
    }

    public string Model
    {
        get { return model; }
        protected set { model = value; }
    }

    public int YearOfProduction
    {
        get { return yearOfProduction; }
        protected set { yearOfProduction = value; }
    }

    public int Horsepower
    {
        get { return horsePower; }
        set { horsePower = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        protected set { acceleration = value; }
    }

    public int Suspension
    {
        get { return suspension; }
        set { suspension = value; }
    }

    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        builder.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s");
        builder.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return builder.ToString().TrimEnd();
    }
}

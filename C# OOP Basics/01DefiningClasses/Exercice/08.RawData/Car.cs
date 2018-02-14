using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }
    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }
    public List<Tire> Tires
    {
        get { return tires; }
        set { tires = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = "n/a";
        this.color = "n/a";
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

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder()
            .AppendLine($"{this.model}:")
            .AppendLine($"  {this.Engine.Model}:")
            .AppendLine($"      Power: {this.Engine.Power}")
            .AppendLine($"      Displacement: {this.Engine.Displacement}")
            .AppendLine($"      Efficiency: {this.Engine.Efficiency}")
            .AppendLine($"  Weight: {this.weight}")
            .AppendLine($"  Color: {this.color}");

        return builder.ToString();
    }
}

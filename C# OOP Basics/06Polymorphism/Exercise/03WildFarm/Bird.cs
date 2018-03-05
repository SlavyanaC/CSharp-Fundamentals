using System.Collections.Generic;

public abstract class Bird : Animal
{
    public Dictionary<string, double> typeAndWeightGain = new Dictionary<string, double>
    {
        {"Hen", 0.35 },
        {"Owl",  0.25 },
    };


    public Bird(string name, double weight, double wingSize)
        : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    public double WingSize { get; set; }
}

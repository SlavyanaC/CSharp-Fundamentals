using System.Collections.Generic;

public abstract class Centre
{
    protected Centre(string name)
    {
        this.Name = name;
        this.StroredAnimals = new Dictionary<Animal, string>();
    }

    public string Name { get; }

    public Dictionary<Animal, string> StroredAnimals { get; private set; }
}

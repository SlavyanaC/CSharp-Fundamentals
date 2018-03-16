using System.Collections.Generic;

public abstract class Centre
{
    protected Centre(string name)
    {
        this.Name = name;
        this.StroredAnimals = new List<Animal>();
    }

    public string Name { get; }

    public List<Animal> StroredAnimals { get; private set; }
}

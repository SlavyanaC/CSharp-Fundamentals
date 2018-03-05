public abstract class Mammal : Animal
{
    public Mammal(string name, double weight, string region) 
        : base(name, weight)
    {
        this.Region = region;
    }

    public string Region { get; set; }
}

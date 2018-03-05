public abstract class Feline : Mammal
{
    public Feline(string name, double weight, string region, string breed)
        : base(name, weight, region)
    {
        this.Breed = breed;
    }

    public string Breed { get; set; }
}

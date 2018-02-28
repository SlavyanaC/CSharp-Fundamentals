public class Rebel : IName, IAge, IBuyer
{
    public string Name { get; private set; }

    public int Age { get; private set; }

    public int Food { get; private set; }

    public Rebel(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public void BuyFood()
    {
        this.Food = 5;
    }
}

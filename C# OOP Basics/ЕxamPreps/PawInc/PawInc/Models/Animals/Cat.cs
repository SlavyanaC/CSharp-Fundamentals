public class Cat : Animal
{
    public Cat(string name, int age, int intelliganceCoefficient)
        : base(name, age)
    {
    }

    public int IntelliganceCoefficient { get; }
}

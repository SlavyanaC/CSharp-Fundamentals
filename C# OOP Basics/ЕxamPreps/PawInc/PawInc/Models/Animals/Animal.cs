public abstract class Animal
{
    protected Animal(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; }

    public int Age { get; }

    public bool CleansingStatus { get; private set; }

    public void Cleanse()
    {
        this.CleansingStatus = true;
    }
}

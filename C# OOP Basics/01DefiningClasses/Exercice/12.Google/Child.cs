public class Child
{
    private string name;
    private string birthday;

    public Child()
    {
        this.name = string.Empty;
        this.birthday = string.Empty;
    }

    public Child(string name, string birthday)
        : this()
    {
        this.name = name;
        this.birthday = birthday;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public override string ToString()
    {
        return $"{this.name} {this.birthday}";
    }
}
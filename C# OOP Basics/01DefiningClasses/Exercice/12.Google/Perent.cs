public class Parent
{
    private string name;
    private string birthday;

    public Parent()
    {
        this.name = string.Empty;
        this.birthday = string.Empty;
    }

    public Parent(string name, string birthday)
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
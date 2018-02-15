public class Pokemon
{
    private string name;
    private string type;

    public Pokemon()
    {
        this.name = string.Empty;
        this.type = string.Empty;
    }

    public Pokemon(string name, string type)
        : this()
    {
        this.name = name;
        this.type = type;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public override string ToString()
    {
        return $"{this.name} {this.type}";
    }
}
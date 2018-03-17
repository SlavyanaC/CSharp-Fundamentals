public abstract class Hardware
{
    protected Hardware(string name, int capacity, int memory)
    {
        this.Name = name;
        this.Capacity = capacity;
        this.Memory = memory;
    }

    public virtual string Type { get; }

    public string Name { get; }

    public virtual int Capacity { get; protected set; }

    public virtual int Memory { get; protected set; }
}

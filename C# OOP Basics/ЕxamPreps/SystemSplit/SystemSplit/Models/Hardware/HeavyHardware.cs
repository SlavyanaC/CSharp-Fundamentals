public class HeavyHardware : Hardware
{
    public HeavyHardware(string name, int capacity, int memory)
        : base(name, capacity, memory) { }

    public override string Type => "Heavy";

    public override int Capacity => base.Capacity * 2;

    public override int Memory => base.Memory - (base.Memory * 25 / 100);
}

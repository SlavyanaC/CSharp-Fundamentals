public class PowerHardware : Hardware
{
    public PowerHardware(string name, int capacity, int memory)
        : base(name, capacity, memory) { }

    public override string Type => "Power";

    public override int Capacity => base.Capacity - (base.Capacity * 75 / 100);

    public override int Memory => base.Memory + (base.Memory * 75 / 100);
}

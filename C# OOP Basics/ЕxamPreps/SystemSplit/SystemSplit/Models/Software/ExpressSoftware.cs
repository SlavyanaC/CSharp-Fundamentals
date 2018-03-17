public class ExpressSoftware : Software
{
    public ExpressSoftware(string name, int capacityConsumption, int memoryConsumption)
        : base(name, capacityConsumption, memoryConsumption) { }

    public override int MemoryConsumption => base.MemoryConsumption * 2;
}

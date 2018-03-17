public class LightSoftware : Software
{
    public LightSoftware(string name, int capacityConsumption, int memoryConsumption)
        : base(name, capacityConsumption, memoryConsumption) { }

    public override int CapacityConsumption => base.CapacityConsumption + (base.CapacityConsumption * 50 / 100);

    public override int MemoryConsumption => base.MemoryConsumption - (base.MemoryConsumption * 50 / 100);

}

namespace RecyclingStation.BusinessLayer.Entities.Garbages
{
    using RecyclingStation.BusinessLayer.Attributes;
    using RecyclingStation.BusinessLayer.Strategies;

    [StorableStrategy(typeof(StorableGarbageDisposalStrategy))]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}

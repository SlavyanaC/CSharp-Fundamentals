namespace RecyclingStation.BusinessLayer.Entities.Garbages
{
    using RecyclingStation.BusinessLayer.Attributes;
    using RecyclingStation.BusinessLayer.Strategies;

    [RecyclableStrategy(typeof(RecyclableGarbageDisposalStrategy))]
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}

namespace RecyclingStation.BusinessLayer.Entities.Garbages
{
    using RecyclingStation.BusinessLayer.Attributes;
    using RecyclingStation.BusinessLayer.Strategies;

    [BurnableStrategy(typeof(BurnableGarbageDisposalStrategy))]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}

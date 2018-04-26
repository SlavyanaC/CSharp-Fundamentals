namespace StorageMaster.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        private const int TruckCapacity = 5;

        public Truck()
            : base(TruckCapacity)
        {
        }
    }
}

namespace StorageMaster.Entities.Storages
{
    using System.Collections.Generic;
    using Entities.Vehicles;

    public class DistributionCenter : Storage
    {
        private const int InitialCapacity = 2;
        private const int InitialCapacityGarageSlots = 5;

        public DistributionCenter(string name)
            : base(name, InitialCapacity, InitialCapacityGarageSlots, InitializeVehicles())
        {
        }

        private static IEnumerable<Vehicle> InitializeVehicles()
        {
            return new Vehicle[] {
                new Van(),
                new Van(),
                new Van(),
            };
        }
    }
}

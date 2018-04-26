namespace StorageMaster.Entities.Storages
{
    using System.Collections.Generic;
    using Entities.Vehicles;

    public class AutomatedWarehouse : Storage
    {
        private const int InitialCapacity = 1;
        private const int InitialCapacityGarageSlots = 2;

        public AutomatedWarehouse(string name)
            : base(name, InitialCapacity, InitialCapacityGarageSlots, InitializeVehicles())
        {
        }

        private static IEnumerable<Vehicle> InitializeVehicles()
        {
            return new Vehicle[] { new Truck() };
        }
    }
}

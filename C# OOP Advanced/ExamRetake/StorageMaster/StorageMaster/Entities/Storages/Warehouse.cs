namespace StorageMaster.Entities.Storages
{
    using System.Collections.Generic;
    using Entities.Vehicles;

    public class Warehouse : Storage
    {
        private const int InitialCapacity = 10;
        private const int InitialCapacityGarageSlots = 10;

        public Warehouse(string name)
            : base(name, InitialCapacity, InitialCapacityGarageSlots, InitializeVehicles())
        {
        }

        private static IEnumerable<Vehicle> InitializeVehicles()
        {
            return new Vehicle[] {
                new Semi(),
                new Semi(),
                new Semi(),
            };
        }
    }
}

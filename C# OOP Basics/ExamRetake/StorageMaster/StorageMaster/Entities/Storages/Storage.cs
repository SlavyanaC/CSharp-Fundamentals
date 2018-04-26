namespace StorageMaster.Entities.Storages
{
    using Entities.Products;
    using Entities.Vehicles;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public abstract class Storage
    {
        private List<Vehicle> garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = this.InitializeGarage(vehicles);
            this.products = new List<Product>();
        }

        private List<Vehicle> InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            List<Vehicle> resultGarage = new List<Vehicle>();
            foreach (var vehicle in vehicles)
            {
                resultGarage.Add(vehicle);
            }
            for (int i = vehicles.Count(); i < this.GarageSlots; i++)
            {
                resultGarage.Add(null);
            }

            return resultGarage;
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(Constants.InvalidSlot);
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException(Constants.EmptySlot);
            }

            Vehicle vehicle = this.garage[garageSlot];
            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            if (!deliveryLocation.garage.Any(g => g == null))
            {
                throw new InvalidOperationException(Constants.FullGarage);
            }

            this.garage[garageSlot] = null;
            int assignedSlot = 0;
            for (int i = 0; i < deliveryLocation.garage.Count; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    deliveryLocation.garage[i] = vehicle;
                    assignedSlot = i;
                    break;
                }
            }

            return assignedSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(Constants.FullStorage);
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            int count = 0;
            while (!IsFull && !vehicle.IsEmpty)
            {
                this.products.Add(vehicle.Unload());
                count++;
            }

            return count;
        }
    }
}

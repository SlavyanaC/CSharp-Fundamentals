namespace StorageMaster.Core
{
    using Entities.Products;
    using Entities.Storages;
    using Entities.Vehicles;
    using Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageMaster
    {
        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        private List<Product> productsPool;
        private List<Storage> storageRegistry;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();

            this.productsPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);
            this.productsPool.Add(product);

            return string.Format(Constants.AddedProduct, type);
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storageRegistry.Add(storage);

            return string.Format(Constants.RegisterStorage, name);
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            Vehicle vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return string.Format(Constants.SelectVehicle, vehicle.GetType().Name);
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var counter = 0;
            foreach (var product in productNames)
            {
                Product currentProduct = this.productsPool.LastOrDefault(p => p.GetType().Name == product);
                if (currentProduct == null)
                {
                    throw new InvalidOperationException(string.Format(Constants.ProductOutOfStock, product));
                }

                for (int i = this.productsPool.Count - 1; i >= 0; i--)
                {
                    if (this.productsPool[i] == currentProduct)
                    {
                        this.productsPool.RemoveAt(i);
                    }
                }

                this.currentVehicle.LoadProduct(currentProduct);
                counter++;

                if (counter >= this.currentVehicle.Capacity)
                {
                    break;
                }
            }

            return string.Format(Constants.ProductLoadedMsg, counter, productNames.Count(), this.currentVehicle.GetType().Name);
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storageRegistry.FirstOrDefault(s => s.Name == sourceName);
            Storage destinationStorage = this.storageRegistry.FirstOrDefault(s => s.Name == destinationName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidStorage, "source"));
            }
            if (destinationStorage == null)
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidStorage, "destination"));
            }

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return string.Format(Constants.VehicleSentMsg, vehicle.GetType().Name, destinationName, destinationGarageSlot);
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            Vehicle vehicle = storage.GetVehicle(garageSlot);

            var totalItems = vehicle.Trunk.Count;
            var unloaded = storage.UnloadVehicle(garageSlot);

            var result = string.Format(Constants.VehicleUnloadMsg, unloaded, totalItems, storageName);
            return result;
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            StringBuilder result = new StringBuilder();

            var groupedProducts = storage.Products
                .GroupBy(p => p.GetType().Name)
                .OrderByDescending(p => p.Count())
                .ThenBy(p => p.Key);

            StringBuilder storageInfoGroup = new StringBuilder();
            foreach (var group in groupedProducts)
            {
                storageInfoGroup.Append(group.Key + $" ({group.Count()}), ");
            }

            var totalWeight = storage.Products.Sum(p => p.Weight);
            var storageCapacity = storage.Capacity;

            result.AppendLine(string.Format(Constants.StockStatusMsg,
                totalWeight,
                storageCapacity,
                storageInfoGroup.ToString().TrimEnd(',', ' ')));

            var garagesNames = new List<string>();
            foreach (var garage in storage.Garage)
            {
                if (garage == null)
                    garagesNames.Add("empty");
                else
                    garagesNames.Add(garage.GetType().Name);
            }

            result.AppendLine(string.Format(Constants.StockGarageStatusMsg, string.Join("|", garagesNames)));

            return result.ToString().Trim();
        }

        public string GetSummary()
        {
            StringBuilder result = new StringBuilder();
            foreach (var storage in this.storageRegistry.OrderByDescending(s => s.Products.Sum(p => p.Price)))
            {
                var totalMoney = storage.Products.Sum(p => p.Price);

                result.AppendLine($"{storage.Name}:");
                result.AppendLine(string.Format(Constants.StorageWorth, totalMoney));
            }

            return result.ToString().Trim();
        }
    }
}

namespace StorageMaster.Entities.Vehicles
{
    using Entities.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Vehicle
    {
        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.trunk = new List<Product>();
            this.Capacity = capacity;
        }

        public int Capacity { get; }

        public IReadOnlyCollection<Product> Trunk
        {
            get => this.trunk;
        }

        public bool IsFull => this.Trunk.Sum(p => p.Weight) > this.Capacity;

        public bool IsEmpty => this.Trunk.Count > 0 ? false : true;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(Constants.FullTruck);
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(Constants.EmptyTruck);
            }

            Product product = this.Trunk.Last();
            this.trunk.RemoveAt(this.trunk.Count - 1);

            return product;
        }
    }
}

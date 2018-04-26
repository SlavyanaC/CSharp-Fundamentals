namespace StorageMaster.Entities.Products
{
    using System;

    public abstract class Product
    {
        private double price;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(Constants.NegativePrice);
                }

                price = value;
            }
        }

        public virtual double Weight { get; protected set; }
    }
}

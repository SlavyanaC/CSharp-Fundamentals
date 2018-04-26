namespace StorageMaster.Factories
{
    using Entities.Products;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Type productType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(p => p.Name == type);

            if (productType == null || productType.IsAbstract)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            try
            {
                Product product = (Product)Activator.CreateInstance(productType, price);
                return product;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

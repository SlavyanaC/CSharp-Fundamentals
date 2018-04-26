namespace StorageMaster.Entities.Products
{
    public class SolidStateDrive : Product
    {
        private const double RamWeight = 0.1;

        public SolidStateDrive(double price) 
            : base(price, RamWeight)
        {
        }
    }
}

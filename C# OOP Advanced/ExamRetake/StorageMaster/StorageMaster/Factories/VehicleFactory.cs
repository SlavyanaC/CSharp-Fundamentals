namespace StorageMaster.Factories
{
    using Entities.Vehicles;
    using System;
    using System.Linq;
    using System.Reflection;

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Type vehicleType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (vehicleType == null || vehicleType.IsAbstract)
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            try
            {
                Vehicle vehicle = (Vehicle)Activator.CreateInstance(vehicleType, null);
                return vehicle;
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }
    }
}

namespace RecyclingStation.BusinessLayer.Factories
{
    using RecyclingStation.BusinessLayer.Contracts.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WasteFactory : IWasteFactory
    {
        private const string GarbageSuffix = "Garbage";

        public IWaste Create(string name, double weight, double volumePerKg, string type)
        {
            string fullTypeName = type + GarbageSuffix;

            Type typeOfGarbageToActivate = Assembly
                .GetExecutingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name.Equals(fullTypeName, StringComparison.OrdinalIgnoreCase));

            object[] ctorArgs = new object[] { name, weight, volumePerKg };

            IWaste waste = (IWaste)Activator.CreateInstance(typeOfGarbageToActivate, ctorArgs);

            return waste;
        }
    }
}

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (model == null)
                throw new ArgumentException("Invalid Unit Type");

            if (!typeof(IUnit).IsAssignableFrom(model))
                throw new ArgumentException($"{unitType} is not a Unit Type");

            IUnit unit = (IUnit)Activator.CreateInstance(model);

            return unit;
        }
    }
}

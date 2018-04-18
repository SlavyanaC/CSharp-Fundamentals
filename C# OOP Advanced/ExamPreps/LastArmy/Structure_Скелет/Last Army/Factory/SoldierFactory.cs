using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type soldierType = Assembly.GetEntryAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(soldierTypeName, StringComparison.OrdinalIgnoreCase));

        object[] ctorParams = new object[] { name, age, experience, endurance };

        ISoldier soldier = (ISoldier)Activator.CreateInstance(soldierType, ctorParams);

        return soldier;
    }
}

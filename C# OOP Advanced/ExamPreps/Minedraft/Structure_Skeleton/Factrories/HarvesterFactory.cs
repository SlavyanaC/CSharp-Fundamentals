using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    private const string HarvesterSuffix = "Harvester";

    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];
        int id = int.Parse(args[1]);
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);

        string fullEntityName = type + HarvesterSuffix;

        Type harvesterType = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(fullEntityName, StringComparison.OrdinalIgnoreCase));

        object[] ctorArgs = new object[] { id, oreOutput, energyRequirement };

        IHarvester harvester = (IHarvester)Activator.CreateInstance(harvesterType, ctorArgs);

        return harvester;
    }
}
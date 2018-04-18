using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string missionName, double neededPoints)
    {
        Type missionType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(missionName, StringComparison.OrdinalIgnoreCase));

        IMission mission = (IMission)Activator.CreateInstance(missionType, neededPoints);
    
        return mission;
    }
}

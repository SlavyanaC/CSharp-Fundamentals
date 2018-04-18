using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string missionName, double neededPoints)
    {
        Type missionType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == missionName);

        return (IMission)Activator.CreateInstance(missionType, neededPoints);
    }
}
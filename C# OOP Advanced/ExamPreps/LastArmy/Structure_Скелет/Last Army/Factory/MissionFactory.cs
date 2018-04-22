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

        if (missionType == null)
        {
            throw new ArgumentException(string.Format(OutputMessages.InvalidType, missionType));
        }

        if (!typeof(IMission).IsAssignableFrom(missionType))
        {
            throw new InvalidOperationException(string.Format(OutputMessages.ObjectNotOfWantedType, missionType, typeof(IMission)));
        }

        IMission mission = (IMission)Activator.CreateInstance(missionType, neededPoints);
    
        return mission;
    }
}

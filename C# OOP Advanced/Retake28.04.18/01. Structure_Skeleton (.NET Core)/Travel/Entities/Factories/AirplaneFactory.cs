namespace Travel.Entities.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;
    using Contracts;
    using Airplanes.Contracts;
    using Travel.Core;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string type)
        {
            Type airplaneType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (airplaneType == null)
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidType, type));
            }

            if (!typeof(IAirplane).IsAssignableFrom(airplaneType))
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidAssignment, type, "airplane"));
            }

            IAirplane airplane = (IAirplane)Activator.CreateInstance(airplaneType, null);
            return airplane;
        }
    }
}
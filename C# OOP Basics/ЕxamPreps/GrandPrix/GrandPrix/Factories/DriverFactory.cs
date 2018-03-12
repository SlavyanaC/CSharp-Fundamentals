using System;
using System.Collections.Generic;

public static class DriverFactory
{
    public static Driver Create(List<string> arguments, Car car)
    {
        var type = arguments[0];
        var name = arguments[1];
        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(name, car);
            case "Endurance":
                return new EnduranceDriver(name, car);
            default:
                throw new ArgumentException();
        }
    }
}

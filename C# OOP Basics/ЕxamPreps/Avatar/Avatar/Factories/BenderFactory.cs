using System;
using System.Collections.Generic;

public class BenderFactory
{
    public static Bender Create(List<string> args)
    {
        var type = args[0];
        var name = args[1];
        var power = int.Parse(args[2]);
        var additionalInfo = double.Parse(args[3]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, additionalInfo);
            case "Earth":
                return new EarthBender(name, power, additionalInfo);
            case "Fire":
                return new FireBender(name, power, additionalInfo);
            case "Water":
                return new WaterBender(name, power, additionalInfo);
            default:
                throw new ArgumentException();
        }
    }
}

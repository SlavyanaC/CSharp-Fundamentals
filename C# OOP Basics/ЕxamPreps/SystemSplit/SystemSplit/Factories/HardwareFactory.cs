using System;
using System.Collections.Generic;

public class HardwareFactory
{
    public Hardware Create(string type, List<string> args)
    {
        var name = args[0];
        var capacity = int.Parse(args[1]);
        var memory = int.Parse(args[2]);

        switch (type)
        {
            case "power":
                return new PowerHardware(name, capacity, memory);
            case "heavy":
                return new HeavyHardware(name, capacity, memory);
            default:
                throw new ArgumentException();
        }
    }
}

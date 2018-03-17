using System;
using System.Collections.Generic;

public class SoftwareFactory
{
    public Software Create(string type, List<string> args)
    {
        var name = args[1];
        var capacity = int.Parse(args[2]);
        var memory = int.Parse(args[3]);

        switch (type)
        {
            case "express":
                return new ExpressSoftware(name, capacity, memory);
            case "light":
                return new LightSoftware(name, capacity, memory);
            default:
                throw new ArgumentException();
        }
    }
}

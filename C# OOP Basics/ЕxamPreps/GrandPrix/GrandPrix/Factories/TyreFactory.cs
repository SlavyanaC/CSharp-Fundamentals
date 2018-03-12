using System;
using System.Collections.Generic;

public static class TyreFactory
{
    public static Tyre Create(List<string> arguments)
    {
        var type = arguments[0];
        var hardness = double.Parse(arguments[1]);
        switch (type)
        {
            case "Hard":
                return new HardTyre(hardness);
            case "Ultrasoft":
                var grip = double.Parse(arguments[2]);
                return new UltrasoftTyre(hardness, grip);
            default:
                throw new ArgumentException();
        }
    }
}

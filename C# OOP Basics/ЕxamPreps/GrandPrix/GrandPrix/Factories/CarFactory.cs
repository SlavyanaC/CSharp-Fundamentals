using System.Collections.Generic;

public static class CarFactory
{
    public static Car Create(List<string> arguments, Tyre tyre)
    {
        var horsepower = int.Parse(arguments[0]);
        var fuelAmount = double.Parse(arguments[1]);
        return new Car(horsepower, fuelAmount, tyre);
    }
}

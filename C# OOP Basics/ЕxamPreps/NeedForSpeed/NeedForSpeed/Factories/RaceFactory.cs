using System;

public class RaceFactory
{
    public static Race CreateRace(string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                return new CasualRace(length, route, prizePool);
            case "Drag":
                return new DragRace(length, route, prizePool);
            case "Drift":
                return new DriftRace(length, route, prizePool);
            default:
                throw new ArgumentException();
        }
    }

    public static Race CreateRace(string type, int length, string route, int prizePool, int additionalInfo)
    {
        switch (type)
        {
            case "TimeLimit":
                return new TimeLimitRace(length, route, prizePool,additionalInfo);
            case "Circuit":
                return new CircuitRace(length, route, prizePool, additionalInfo);
            default:
                throw new ArgumentException();
        }
    }
}

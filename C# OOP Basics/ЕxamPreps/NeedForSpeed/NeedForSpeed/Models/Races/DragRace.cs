using System.Collections.Generic;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool)
        : base(length, route, prizePool) { }

    public override string ToString()
    {
        var CarsPerformancePoints = new Dictionary<int, Car>();
        if (this.Cars.Count > 0)
        {
            foreach (var car in Cars.Values)
            {
                var points = (car.HorsePower / car.Acceleration);
                CarsPerformancePoints[points] = car;
            }
        }

        var raceResults = this.GetRaceResults(CarsPerformancePoints);
        return raceResults;
    }
}

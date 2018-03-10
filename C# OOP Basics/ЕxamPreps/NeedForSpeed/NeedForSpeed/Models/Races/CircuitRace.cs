using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race, ICircuitRacePrize
{
    public CircuitRace(int length, string route, int prizePool, int laps)
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps { get; private set; }

    public override int FirstPrize => this.PrizePool * 40 / 100;

    public override int SecondPrize => this.PrizePool * 30 / 100;

    public override int ThirdPrize => this.PrizePool * 20 / 100;

    public int FourthPrize => this.PrizePool * 10 / 100;

    public override string ToString()
    {
        for (int i = 0; i < this.Laps; i++)
        {
            foreach (var car in this.Cars)
            {
                car.Value.Durability -= this.Length * this.Length;
            }

        }

        var CarsPerformancePoints = new Dictionary<int, Car>();
        if (this.Cars.Count > 0)
        {
            foreach (var car in this.Cars.Values)
            {
                var points = (car.Horsepower / car.Acceleration) + (car.Suspension + car.Durability);
                CarsPerformancePoints[points] = car;
            }
        }

        var raceResults = this.GetCircuitRaceResults(CarsPerformancePoints);
        return raceResults;
    }

    public string GetCircuitRaceResults(Dictionary<int, Car> carsPerformancePoints)
    {
        StringBuilder raceResults = new StringBuilder();
        raceResults.AppendLine($"{this.Route} - {this.Laps * this.Length}");

        carsPerformancePoints = carsPerformancePoints.OrderByDescending(c => c.Key).ToDictionary(c => c.Key, c => c.Value);
        if (carsPerformancePoints.Count == 1)
        {
            Car first = carsPerformancePoints.First().Value;
            raceResults.AppendLine($"1. {first.Brand} {first.Model} {carsPerformancePoints.First().Key}PP - ${this.FirstPrize}");
        }
        else if (carsPerformancePoints.Count == 2)
        {
            Car first = carsPerformancePoints.First().Value;
            Car second = carsPerformancePoints.Last().Value;
            raceResults.AppendLine($"1. {first.Brand} {first.Model} {carsPerformancePoints.First().Key}PP - ${this.FirstPrize}");
            raceResults.AppendLine($"2. {second.Brand} {second.Model} {carsPerformancePoints.Last().Key}PP - ${this.SecondPrize}");
        }
        else if (carsPerformancePoints.Count == 3)
        {
            Car first = carsPerformancePoints.First().Value;
            Car second = carsPerformancePoints.Skip(1).Take(1).First().Value;
            Car third = carsPerformancePoints.Last().Value;
            raceResults.AppendLine($"1. {first.Brand} {first.Model} {carsPerformancePoints.First().Key}PP - ${this.FirstPrize}");
            raceResults.AppendLine($"2. {second.Brand} {second.Model} {carsPerformancePoints.Skip(1).Take(1).First().Key}PP - ${this.SecondPrize}");
            raceResults.AppendLine($"3. {third.Brand} {third.Model} {carsPerformancePoints.Last().Key}PP - ${this.FirstPrize}");
        }

        else
        {
            carsPerformancePoints = carsPerformancePoints.Take(4).ToDictionary(c => c.Key, c => c.Value);

            var counter = 1;
            foreach (var car in carsPerformancePoints)
            {
                if (counter == 4)
                {
                    raceResults.AppendLine($"{counter++}. {car.Value.Brand} {car.Value.Model} {car.Key}PP - ${this.FourthPrize}");
                }
                if (counter == 3)
                {
                    raceResults.AppendLine($"{counter++}. {car.Value.Brand} {car.Value.Model} {car.Key}PP - ${this.ThirdPrize}");
                }
                if (counter == 2)
                {
                    raceResults.AppendLine($"{counter++}. {car.Value.Brand} {car.Value.Model} {car.Key}PP - ${this.SecondPrize}");
                }
                if (counter == 1)
                {
                    raceResults.AppendLine($"{counter++}. {car.Value.Brand} {car.Value.Model} {car.Key}PP - ${this.FirstPrize}");
                }
            }
        }

        return raceResults.ToString().TrimEnd();
    }
}

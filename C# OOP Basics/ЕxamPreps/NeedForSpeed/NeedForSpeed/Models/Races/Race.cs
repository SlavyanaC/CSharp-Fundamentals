using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race : IPrize
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> cars;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Cars = new Dictionary<int, Car>();
    }

    public int Length
    {
        get { return length; }
        protected set { length = value; }
    }

    public string Route
    {
        get { return route; }
        protected set { route = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        protected set { prizePool = value; }
    }

    public Dictionary<int, Car> Cars
    {
        get { return cars; }
        set { cars = value; }
    }

    public int FirstPrize => this.PrizePool * 50 / 100;

    public int SecondPrize => this.PrizePool * 30 / 100;

    public int ThirdPrize => this.PrizePool * 20 / 100;

    public void AddCar(int carId, Car car)
    {
        this.Cars[carId] = car;
    }

    public string GetRaceResults(Dictionary<int, Car> carsPerformancePoints)
    {
        StringBuilder raceResults = new StringBuilder();
        raceResults.AppendLine($"{this.Route} - {this.Length}");

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

        else
        {
            carsPerformancePoints = carsPerformancePoints.Take(3).ToDictionary(c => c.Key, c => c.Value);

            var counter = 1;
            foreach (var car in carsPerformancePoints)
            {
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

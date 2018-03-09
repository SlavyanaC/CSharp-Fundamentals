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

    public string GetRaceResults(Dictionary<int, Car> CarsPerformancePoints)
    {
        StringBuilder raceResults = new StringBuilder();
        raceResults.AppendLine($"{this.Route} - {this.Length}");

        if (CarsPerformancePoints.Count == 1)
        {
            Car first = CarsPerformancePoints.First().Value;
            raceResults.AppendLine($"1. {first.Brand} {first.Model} {CarsPerformancePoints.First().Key}PP - ${this.FirstPrize}");
        }
        else if (CarsPerformancePoints.Count == 2)
        {
            Car first = CarsPerformancePoints.First().Value;
            Car second = CarsPerformancePoints.Last().Value;
            raceResults.AppendLine($"1. {first.Brand} {first.Model} {CarsPerformancePoints.First().Key}PP - ${this.FirstPrize}");
            raceResults.AppendLine($"2. {second.Brand} {second.Model} {CarsPerformancePoints.Last().Key}PP - ${this.SecondPrize}");
        }

        else
        {
            var orderedCars = CarsPerformancePoints.OrderByDescending(c => c.Key).Take(3).ToDictionary(c => c.Key, c => c.Value);

            var counter = 1;
            foreach (var car in orderedCars)
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

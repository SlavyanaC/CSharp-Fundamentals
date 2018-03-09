using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool)
        : base(length, route, prizePool) { }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{this.Route} - {this.Length}");

        var pointsAndCars = new Dictionary<int, Car>();
        if (this.Cars.Count > 0)
        {
            foreach (var car in Cars.Values)
            {
                var points = 0;
                points = (car.Suspension / car.Durability);
                pointsAndCars[points] = car;
            }
        }

        if (pointsAndCars.Count == 1)
        {
            Car first = pointsAndCars.First().Value;
            builder.AppendLine($"1. {first.Brand} {first.Model} {pointsAndCars.First().Key}PP - ${this.FirstPrize}");
        }
        else if (pointsAndCars.Count == 2)
        {
            Car first = pointsAndCars.First().Value;
            Car second = pointsAndCars.Last().Value;
            builder.AppendLine($"1. {first.Brand} {first.Model} {pointsAndCars.First().Key}PP - ${this.FirstPrize}");
            builder.AppendLine($"2. {second.Brand} {second.Model} {pointsAndCars.Last().Key}PP - ${this.SecondPrize}");
        }

        else
        {
            var orderedCars = pointsAndCars.OrderByDescending(c => c.Key).Take(3).ToDictionary(c => c.Key, c => c.Value);

            var firstPrize = this.PrizePool * 50 / 100;
            var secondPrize = this.PrizePool * 30 / 100;
            var thirdPrize = this.PrizePool * 20 / 100;

            var counter = 1;
            foreach (var car in orderedCars)
            {
                if (counter == 3)
                {
                    builder.AppendLine($"{counter++}. {car.Value.Brand} {car.Value.Model} {car.Key}PP - ${thirdPrize}");
                }
                if (counter == 2)
                {
                    builder.AppendLine($"{counter++}. {car.Value.Brand} {car.Value.Model} {car.Key}PP - ${secondPrize}");
                }
                if (counter == 1)
                {
                    builder.AppendLine($"{counter++}. {car.Value.Brand} {car.Value.Model} {car.Key}PP - ${firstPrize}");
                }
            }
        }

        return builder.ToString().TrimEnd();
    }
}

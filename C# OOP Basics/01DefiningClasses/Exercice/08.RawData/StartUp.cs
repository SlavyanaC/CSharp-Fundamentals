using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int currentCar = 0; currentCar < carsCount; currentCar++)
            {
                string[] carInfo = Console.ReadLine().Split();
                cars = ParseAndAddCar(cars, carInfo);
            }

            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    foreach (var car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
                case "flamable":
                    foreach (var car in cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
            }
        }

        private static List<Car> ParseAndAddCar(List<Car> cars, string[] carInfo)
        {
            var model = carInfo[0];

            var engineSpeed = int.Parse(carInfo[1]);
            var enginePower = int.Parse(carInfo[2]);

            var cargoWeight = int.Parse(carInfo[3]);
            var cargoType = carInfo[4];

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            List<Tire> tires = new List<Tire>();
            for (int index = 5; index <= 12; index += 2)
            {
                var tirePressure = double.Parse(carInfo[index]);
                var tireAge = int.Parse(carInfo[index + 1]);
                tires.Add(new Tire(tirePressure, tireAge));
            }

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);

            return cars;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.CarSalesman
{
    class StartUp
    {
        static void Main()
        {
            int enginesCount = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int currentEngine = 0; currentEngine < enginesCount; currentEngine++)
            {
                string[] engineTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                engines = ParseEngine(engines, engineTokens);
            }

            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int currentCar = 0; currentCar < carsCount; currentCar++)
            {
                string[] carTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                cars = ParseCar(cars, engines, carTokens);
            }

            foreach (var car in cars)
            {
                Console.Write(car);
            }
        }

        private static List<Car> ParseCar(List<Car> cars, List<Engine> engines,string[] carTokens)
        {
            string model = carTokens[0];
            string engine = carTokens[1];

            Car car = new Car(model, engines.FirstOrDefault(e => e.Model == engine));
            if (carTokens.Length > 2)
            {
                var thirdToken = carTokens[2];
                double weight;
                bool isNumber = double.TryParse(thirdToken, out weight);
                if (isNumber)
                {
                    car.Weight = thirdToken;
                }
                else
                {
                    car.Color = thirdToken;
                }
            }
            if (carTokens.Length > 3)
            {
                string color = carTokens[3];
                car.Color = color;
            }
            cars.Add(car);

            return cars;
        }

        private static List<Engine> ParseEngine(List<Engine> engines, string[] engineTokens)
        {
            string model = engineTokens[0];
            double power = double.Parse(engineTokens[1]);

            Engine engine = new Engine(model, power);
            if (engineTokens.Length > 2)
            {
                var thrirdToken = engineTokens[2];
                double displacement;
                bool isNumber = double.TryParse(thrirdToken, out displacement);

                if (isNumber)
                {
                    engine.Displacement = thrirdToken;
                }
                else
                {
                    engine.Efficiency = thrirdToken;
                }
            }
            if (engineTokens.Length > 3)
            {
                var efficiency = engineTokens[3];
                engine.Efficiency = efficiency;
            }
            engines.Add(engine);

            return engines;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                decimal fuelAmount = decimal.Parse(carInfo[1]);
                decimal fuelConsumption = decimal.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string driveCommand = string.Empty;
            while ((driveCommand = Console.ReadLine()) != "End")
            {
                string[] commandArgs = driveCommand.Split();
                string model = commandArgs[1];
                int kilometers = int.Parse(commandArgs[2]);
                Car currentCar = cars.First(c => c.Model == model);
                currentCar.Drive(kilometers);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}

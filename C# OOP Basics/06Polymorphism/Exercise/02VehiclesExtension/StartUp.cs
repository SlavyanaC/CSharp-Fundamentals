using System;

namespace VehiclesExtension
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var carFuelQuantity = double.Parse(carInfo[1]);
            var carFuelConsumption = double.Parse(carInfo[2]);

            var truckInfo = Console.ReadLine().Split();
            var truckFuelQuantity = double.Parse(truckInfo[1]);
            var truckFuelConsumption = double.Parse(truckInfo[2]);

            Car car = new Car(carFuelQuantity, carFuelConsumption);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                try
                {
                    var commandTokens = Console.ReadLine().Split();
                    var action = commandTokens[0];
                    var vehicleType = commandTokens[1];
                    var parameter = double.Parse(commandTokens[2]);

                    switch (vehicleType)
                    {
                        case "Car":
                            ExecuteCommand(car, action, parameter);
                            break;
                        case "Truck":
                            ExecuteCommand(truck, action, parameter);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        private static void ExecuteCommand(Vehicle vehicle, string action, double parameter)
        {
            if (action == "Drive")
            {
                Console.WriteLine(vehicle.TryDrive(parameter));
            }
            else if (action == "Refuel")
            {
                vehicle.Refuel(parameter);
            }
        }
    }
}

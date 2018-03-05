using System;

namespace VehiclesExtension
{
    // 75/100
    class StartUp
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var carFuelQuantity = double.Parse(carInfo[1]);
            var carFuelConsumption = double.Parse(carInfo[2]);
            var carTankCapacity = double.Parse(carInfo[3]);
            if (carFuelQuantity > carTankCapacity) { carFuelQuantity = 0; }

            var truckInfo = Console.ReadLine().Split();
            var truckFuelQuantity = double.Parse(truckInfo[1]);
            var truckFuelConsumption = double.Parse(truckInfo[2]);
            var truckTankCapacity = double.Parse(truckInfo[3]);
            if (truckFuelQuantity > truckTankCapacity) { truckFuelQuantity = 0; }

            var busInfo = Console.ReadLine().Split();
            var busFuelQuantity = double.Parse(busInfo[1]);
            var busFuelConsumption = double.Parse(busInfo[2]);
            var busTankCapacity = double.Parse(busInfo[3]);
            if (busFuelQuantity > busTankCapacity) { busFuelQuantity = 0; }

            Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

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
                        case "Bus":
                            ExecuteCommand(bus, action, parameter);
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
            Console.WriteLine(bus.ToString());
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
            else if (action == "DriveEmpty")
            {
                Console.WriteLine(vehicle.TryDrive(parameter, false));
            }
        }
    }
}

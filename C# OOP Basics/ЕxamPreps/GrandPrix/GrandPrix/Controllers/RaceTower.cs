using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private Dictionary<Driver, string> drivers = new Dictionary<Driver, string>();
    private Dictionary<Driver, string> failedDrivers = new Dictionary<Driver, string>();
    private int currentLap;
    private string weather = "Sunny";
    public bool isEndOfRace = false;

    public int TotalLaps { get; set; }
    public int TrackLenght { get; set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.TotalLaps = lapsNumber;
        this.TrackLenght = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driverArgs = commandArgs.Take(2).ToList();
            var carArgs = commandArgs.Skip(2).Take(2).ToList();
            var tyreArgs = commandArgs.Skip(4).ToList();

            var tyre = TyreFactory.Create(tyreArgs);
            var car = CarFactory.Create(carArgs, tyre);
            var driver = DriverFactory.Create(driverArgs, car);

            this.drivers[driver] = string.Empty;
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];
        var driverToBox = drivers.FirstOrDefault(d => d.Key.Name == driverName);
        driverToBox.Key.TotalTime += 20;

        switch (reasonToBox)
        {
            case "ChangeTyres":
                var tyreArgs = commandArgs.Skip(2).ToList();
                var newTyre = TyreFactory.Create(tyreArgs);
                driverToBox.Key.Car.ChangeTyre(newTyre);
                break;
            case "Refuel":
                var fuelAmount = double.Parse(commandArgs[2]);
                driverToBox.Key.Car.Refuel(fuelAmount);
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var numberOfLaps = int.Parse(commandArgs[0]);
        try
        {
            if (numberOfLaps + this.currentLap > this.TotalLaps)
                throw new ArgumentException($"There is no time! On lap {this.currentLap}.");
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        for (int currLap = 0; currLap < numberOfLaps; currLap++)
        {
            ExecuteLapOperations();
            var orderedDrivers = drivers.Keys.OrderByDescending(d => d.TotalTime).ToList();
            CheckForOvertaking(orderedDrivers, currLap);
        }

        currentLap += numberOfLaps;
        if (currentLap == this.TotalLaps)
        {
            this.isEndOfRace = true;
            Driver winner = drivers.Keys.OrderBy(d => d.TotalTime).First();
            return $"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.";
        }

        return string.Empty;
    }

    private void ExecuteLapOperations()
    {
        var copyDrivers = new Dictionary<Driver, string>(drivers);
        foreach (var driver in copyDrivers.Keys)
        {
            try
            {
                driver.IncreasTotalTime(this.TrackLenght);
                driver.Car.ReduceFuelAmount(this.TrackLenght, driver.FuelConsumptionPerKm);
                driver.Car.Tyre.ReduceDegradation();
            }
            catch (ArgumentException ae)
            {
                failedDrivers[driver] = ae.Message;
                drivers.Remove(driver);
            }
        }
    }

    private void CheckForOvertaking(List<Driver> orderedDrivers, int currLap)
    {
        var timeInterval = 2;
        for (int i = 0; i < orderedDrivers.Count - 1; i++)
        {
            var firstDriver = orderedDrivers[i];
            var secondDriver = orderedDrivers[i + 1];
            var diff = Math.Abs(firstDriver.TotalTime - secondDriver.TotalTime);

            bool driverHasCrashed = CheckIfDriverHasCrashed(firstDriver, ref timeInterval);
            if (!driverHasCrashed && diff <= timeInterval)
            {
                firstDriver.TotalTime -= timeInterval;
                secondDriver.TotalTime += timeInterval;
                Console.WriteLine($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {++currLap}.");
            }
        }
    }

    private bool CheckIfDriverHasCrashed(Driver firstDriver, ref int timeInterval)
    {
        if (firstDriver.GetType().Name == "AggressiveDriver" && firstDriver.Car.Tyre.GetType().Name == "UltrasoftTyre")
        {
            timeInterval = 3;
            if (this.weather == "Foggy")
            {
                drivers.Remove(firstDriver);
                failedDrivers[firstDriver] = "Crashed";
                return true;
            }
        }

        else if (firstDriver.GetType().Name == "EnduranceDriver" && firstDriver.Car.Tyre.GetType().Name == "HardTyre")
        {
            timeInterval = 3;
            if (this.weather == "Rainy")
            {
                drivers.Remove(firstDriver);
                failedDrivers[firstDriver] = "Crashed";
                return true;
            }
        }

        return false;
    }

    public string GetLeaderboard()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Lap {this.currentLap}/{this.TotalLaps}");

        var position = 1;
        foreach (var driver in drivers.OrderBy(d => d.Key.TotalTime))
        {
            builder.AppendLine($"{position++} {driver.Key.Name} {driver.Key.TotalTime:F3}");
        }
        foreach (var driver in failedDrivers.Reverse())
        {
            builder.AppendLine($"{position++} {driver.Key.Name} {driver.Value}");
        }

        return builder.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        if (commandArgs[0] == "Sunny" || commandArgs[0] == "Rainy" || commandArgs[0] == "Foggy")
        {
            this.weather = commandArgs[0];
        }
    }
}

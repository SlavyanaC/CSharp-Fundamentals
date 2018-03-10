using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private CarManager manager;

    public Engine()
    {
        this.manager = new CarManager();
    }

    public void Run()
    {
        string inputCommand;
        while ((inputCommand = Console.ReadLine()) != "Cops Are Here")
        {
            var commandArgs = inputCommand
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
            DistributeCommands(commandArgs);
        }
    }

    private void DistributeCommands(List<string> commandArgs)
    {
        var command = commandArgs[0];
        commandArgs = commandArgs.ToList();

        switch (command)
        {
            case "register":
                var id = int.Parse(commandArgs[1]);
                var type = commandArgs[2];
                var brand = commandArgs[3];
                var model = commandArgs[4];
                var year = int.Parse(commandArgs[5]);
                var horsepower = int.Parse(commandArgs[6]);
                var acceleration = int.Parse(commandArgs[7]);
                var suspension = int.Parse(commandArgs[8]);
                var durability = int.Parse(commandArgs[9]);
                this.manager.Register(id, type, brand, model, year, horsepower, acceleration, suspension, durability);
                break;
            case "check":
                Console.WriteLine(this.manager.Check(int.Parse(commandArgs[1])));
                break;
            case "open":
                var idRace = int.Parse(commandArgs[1]);
                var raceType = commandArgs[2];
                var length = int.Parse(commandArgs[3]);
                var route = commandArgs[4];
                var prizePool = int.Parse(commandArgs[5]);
                this.manager.Open(idRace, raceType, length, route, prizePool);
                break;
            case "participate":
                var carId = int.Parse(commandArgs[1]);
                var raceId = int.Parse(commandArgs[2]);
                this.manager.Participate(carId, raceId);
                break;
            case "start":
                Console.WriteLine(this.manager.Start(int.Parse(commandArgs[1])));
                break;
            case "park":
                this.manager.Park(int.Parse(commandArgs[1]));
                break;
            case "unpark":
                this.manager.Unpark(int.Parse(commandArgs[1]));
                break;
            case "tune":
                this.manager.Tune(int.Parse(commandArgs[1]), commandArgs[2]);
                break;
        }
    }
}
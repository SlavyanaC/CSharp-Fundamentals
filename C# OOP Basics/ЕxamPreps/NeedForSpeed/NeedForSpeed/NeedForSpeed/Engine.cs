using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private CarManager carManager;

    public Engine()
    {
        this.carManager = new CarManager();
    }

    public void Run()
    {
        var inputLine = string.Empty;
        while ((inputLine= Console.ReadLine())!= "Cops Are Here")
        {
            var commandArgs = inputLine
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            DistributeCommand(commandArgs);
        }
    }

    private void DistributeCommand(List<string> commandArgs)
    {
        var command = commandArgs[0];
        commandArgs = commandArgs.Skip(1).ToList();
        switch (command)
        {
            case "register":
                this.carManager.Register(int.Parse(commandArgs[0]),
                                                   commandArgs[1], 
                                                   commandArgs[2],
                                                   commandArgs[3], 
                                         int.Parse(commandArgs[4]), 
                                         int.Parse(commandArgs[5]), 
                                         int.Parse(commandArgs[6]), 
                                         int.Parse(commandArgs[7]),
                                         int.Parse(commandArgs[8]));
                break;

            case "check":
                Console.WriteLine(carManager.Check(int.Parse(commandArgs[0])));
                break;

            case "open":
                this.carManager.Open(int.Parse(commandArgs[0]),
                                               commandArgs[1],
                                    int.Parse(commandArgs[2]),
                                              commandArgs[3],
                                    int.Parse(commandArgs[4]));
                break;

            case "participate":
                this.carManager.Participate(int.Parse(commandArgs[0]),
                                            int.Parse(commandArgs[1]));
                break;

            case "start":
                Console.WriteLine(carManager.Start(int.Parse(commandArgs[0])));
                break;

            case "park":
                this.carManager.Park(int.Parse(commandArgs[0]));
                break;

            case "unpark":
                this.carManager.Unpark(int.Parse(commandArgs[0]));
                break;

            case "tune":
                this.carManager.Tune(int.Parse(commandArgs[0]),
                                               commandArgs[1]);
                break;

            default:
                throw new ArgumentException();
        }
    }
}

using System;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    public void Run()
    {
        var totalLaps = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());
        this.raceTower.SetTrackInfo(totalLaps, trackLength);

        string input = Console.ReadLine();
        while (true)
        {
            var commandArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = commandArgs[0];
            commandArgs = commandArgs.Skip(1).ToList();

            switch (command)
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(commandArgs);
                    break;
                case "Box":
                    raceTower.DriverBoxes(commandArgs);
                    break;
                case "CompleteLaps":
                    var result = raceTower.CompleteLaps(commandArgs);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                        if (this.raceTower.isEndOfRace)
                        {
                            return;
                        }
                    }
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(commandArgs);
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}

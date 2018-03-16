using System;
using System.Linq;

public class Engine
{
    PawsMenager pawsMenager = new PawsMenager();

    public void Run()
    {
        var inputLine = Console.ReadLine();
        while (true)
        {
            var commandArgs = inputLine.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = commandArgs[0];
            commandArgs = commandArgs.Skip(1).ToList();
            switch (command)
            {
                case "RegisterCleansingCenter":
                    this.pawsMenager.RegisterCleansingCenter(commandArgs);
                    break;
                case "RegisterAdoptionCenter":
                    this.pawsMenager.RegisterAdoptionCenter(commandArgs);
                    break;
                case "RegisterCastrationCenter":
                    this.pawsMenager.RegisterCastrationCenter(commandArgs);
                    break;
                case "RegisterDog":
                    this.pawsMenager.RegisterDog(commandArgs);
                    break;
                case "RegisterCat":
                    this.pawsMenager.RegisterCat(commandArgs);
                    break;
                case "SendForCleansing":
                    this.pawsMenager.SendForCleansing(commandArgs);
                    break;
                case "SendForCastration":
                    this.pawsMenager.SendForCastration(commandArgs);
                    break;
                case "Cleanse":
                    this.pawsMenager.Cleanse(commandArgs);
                    break;
                case "Castrate":
                    this.pawsMenager.Castrate(commandArgs);
                    break;
                case "Adopt":
                    this.pawsMenager.Adopt(commandArgs);
                    break;
                case "CastrationStatistics":
                    Console.WriteLine(this.pawsMenager.CastrationStatistics());
                    break;
                case "Paw Paw Pawah":
                    Console.WriteLine(this.pawsMenager.Output());
                    return;
            }

            inputLine = Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                case "RegisterDog":
                    this.pawsMenager.RegisterDog(commandArgs);
                    break;
                case "RegisterCat":
                    this.pawsMenager.RegisterCat(commandArgs);
                    break;
                case "SendForCleansing":
                    this.pawsMenager.SendForCleansing(commandArgs);
                    break;
                case "Cleanse":
                    this.pawsMenager.Cleanse(commandArgs);
                    break;
                case "Adopt":
                    this.pawsMenager.Adopt(commandArgs);
                    break;
                case "Paw Paw Pawah":
                    Console.WriteLine(this.pawsMenager.Terminate());
                    return;
            }

            inputLine = Console.ReadLine();
        }
    }
}

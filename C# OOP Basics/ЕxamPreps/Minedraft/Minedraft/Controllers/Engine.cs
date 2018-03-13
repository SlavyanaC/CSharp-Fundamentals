using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning = true;
    private DraftManager draftManager = new DraftManager();

    public void Run()
    {
        while (this.isRunning == true)
        {
            var arguments = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList(); ;
            ExecuteCommand(arguments);
        }
    }

    private void ExecuteCommand(List<string> arguments)
    {
        var command = arguments[0];
        arguments = arguments.Skip(1).ToList();
        switch (command)
        {
            case "RegisterHarvester":
                Console.WriteLine(this.draftManager.RegisterHarvester(arguments));
                break;
            case "RegisterProvider":
                Console.WriteLine(this.draftManager.RegisterProvider(arguments));
                break;
            case "Day":
                Console.WriteLine(this.draftManager.Day());
                break;
            case "Mode":
                Console.WriteLine(this.draftManager.Mode(arguments));
                break;
            case "Check":
                Console.WriteLine(this.draftManager.Check(arguments));
                break;
            case "Shutdown":
                Console.WriteLine(this.draftManager.ShutDown());
                isRunning = false;
                break;
            default:
                break;
        }
    }
}

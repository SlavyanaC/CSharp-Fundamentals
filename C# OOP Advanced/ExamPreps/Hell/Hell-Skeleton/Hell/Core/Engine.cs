using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IEngine
{
    private const string CommandSuffix = "Command";

    private IOutputReader reader;
    private IOutputWriter writer;
    private IHeroManager heroManager;
    private ICommandManager commandManager;

    public Engine(IOutputReader reader, IOutputWriter writer, IHeroManager heroManager, ICommandManager commandManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
        this.commandManager = commandManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> arguments = this.ParseInput(inputLine);
            string commandResult = this.ProcessInput(arguments);
            this.writer.WriteLine(commandResult);

            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ProcessInput(List<string> arguments)
    {
        string command = arguments[0] + CommandSuffix;
        arguments.RemoveAt(0);

        var result = this.commandManager.ProcessCommand(command, arguments);
        return result;
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}
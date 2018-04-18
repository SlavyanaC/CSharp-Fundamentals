using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandManager : ICommandManager
{
    IHeroManager heroManager;

    public CommandManager(IHeroManager heroManager)
    {
        this.heroManager = heroManager;
    }

    public string ProcessCommand(string commandName, List<string> args)
    {
        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));

        if (commandType.Name.Equals(nameof(QuitCommand)))
        {
            return heroManager.Quit();
        }
        ICommand command = (ICommand)Activator.CreateInstance(commandType, args, this.heroManager);

        var result = command.Execute();

        return result;
    }
}

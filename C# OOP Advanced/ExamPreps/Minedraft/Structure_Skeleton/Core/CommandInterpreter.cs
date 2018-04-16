using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController
    {
        get => this.harvesterController;
        private set => this.harvesterController = value;
    }

    public IProviderController ProviderController
    {
        get => this.providerController;
        private set => this.providerController = value;
    }

    public string ProcessCommand(IList<string> args)
    {
        string commandName = args[0];
        args = args.Skip(1).ToList();
        string commandFullName = commandName + CommandSuffix;

        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(commandFullName, StringComparison.OrdinalIgnoreCase));

        object[] ctorParams = new object[] { args, this.HarvesterController, this.ProviderController };

        ICommand command = (ICommand)Activator.CreateInstance(commandType, ctorParams);

        string result = command.Execute();

        return result;
    }
}

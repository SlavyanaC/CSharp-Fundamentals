using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IEnergyRepository energyRepository = new EnergyRepository();

        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IHarvesterController harvesterController = new HarvesterController(harvesterFactory, new List<IHarvester>(), energyRepository);
        IProviderController providerController = new ProviderController(energyRepository);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        IEngine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}
using System.Collections.Generic;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string result = string.Format(Constants.SystemShutDown, this.providerController.TotalEnergyProduced, this.harvesterController.ОreOutput);
        return result;
    }
}

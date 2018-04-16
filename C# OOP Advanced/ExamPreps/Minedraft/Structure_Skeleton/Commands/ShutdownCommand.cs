using System.Collections.Generic;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        string result = string.Format(Constants.SystemShutDown, this.ProviderController.TotalEnergyProduced, this.HarvesterController.ОreOutput);
        return result;
    }
}

using System.Collections.Generic;
using System.Linq;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        double value = double.Parse(this.Arguments.First());
        var result = this.ProviderController.Repair(value);

        return result;
    }
}

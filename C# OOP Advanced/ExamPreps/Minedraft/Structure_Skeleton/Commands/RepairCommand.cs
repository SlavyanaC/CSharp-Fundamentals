using System.Collections.Generic;
using System.Linq;

public class RepairCommand : Command
{
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments, IProviderController providerController)
        : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        double value = double.Parse(this.Arguments.First());
        var result = this.providerController.Repair(value);

        return result;
    }
}

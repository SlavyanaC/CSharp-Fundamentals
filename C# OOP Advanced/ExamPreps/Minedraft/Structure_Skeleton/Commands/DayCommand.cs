using System.Collections.Generic;
using System.Text;

public class DayCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(this.providerController.Produce());
        builder.AppendLine(this.harvesterController.Produce());

        return builder.ToString().Trim();
    }
}

using System.Collections.Generic;
using System.Text;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(this.ProviderController.Produce());
        builder.AppendLine(this.HarvesterController.Produce());

        return builder.ToString().Trim();
    }
}

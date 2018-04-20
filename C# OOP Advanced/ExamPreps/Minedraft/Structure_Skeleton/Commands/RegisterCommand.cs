using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string entityTypeAsString = this.Arguments[0];

        if (entityTypeAsString.Equals(nameof(Harvester)))
        {
           return this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }

        if (entityTypeAsString.Equals(nameof(Provider))) 
        {
           return this.providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return string.Format(Constants.UnsuccessfullRegistration, this.Arguments[0]);
    }
}
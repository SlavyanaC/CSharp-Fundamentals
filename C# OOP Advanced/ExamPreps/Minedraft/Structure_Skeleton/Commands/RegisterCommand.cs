using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        string entityTypeAsString = this.Arguments[0];
        List<string> tokens = this.Arguments.Skip(1).ToList();

        if (entityTypeAsString.Equals(nameof(Harvester)))
        {
           return this.HarvesterController.Register(tokens);
        }

        if (entityTypeAsString.Equals(nameof(Provider))) 
        {
           return this.ProviderController.Register(tokens);
        }

        return string.Format(Constants.UnsuccessfullRegistration, tokens[0]);
    }
}
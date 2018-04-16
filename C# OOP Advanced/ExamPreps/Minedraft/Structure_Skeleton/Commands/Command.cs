using System.Collections.Generic;

public abstract class Command : ICommand
{
    private IList<string> arguments;
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public Command(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
    {
        this.Arguments = arguments;
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IList<string> Arguments
    {
        get => this.arguments;
        set => this.arguments = value;
    }

    public IHarvesterController HarvesterController
    {
        get => this.harvesterController;
        set => this.harvesterController = value;
    }

    public IProviderController ProviderController
    {
        get => this.providerController;
        set => this.providerController = value;
    }

    public abstract string Execute();
}

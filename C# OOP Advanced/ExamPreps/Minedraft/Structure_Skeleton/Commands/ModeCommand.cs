using System.Collections.Generic;
using System.Linq;

public class ModeCommand : Command
{
    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        var result = this.harvesterController.ChangeMode(this.Arguments.First());
        return result;
    }
}

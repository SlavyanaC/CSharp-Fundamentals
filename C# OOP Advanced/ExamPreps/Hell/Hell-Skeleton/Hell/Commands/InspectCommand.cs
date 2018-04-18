using System.Collections.Generic;
using System.Linq;

public class InspectCommand : AbstractCommand
{
    public InspectCommand(IList<string> arguments, IHeroManager heroMenager) 
        : base(arguments, heroMenager)
    {
    }

    public override string Execute()
    {
        var result = this.HeroMenager.Inspect(this.Arguments.ToList());
        return result;
    }
}


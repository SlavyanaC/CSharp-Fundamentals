using System.Collections.Generic;
using System.Linq;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(IList<string> arguments, IHeroManager heroMenager) 
        : base(arguments, heroMenager)
    {
    }

    public override string Execute()
    {
        var result = this.HeroMenager.AddItemToHero(this.Arguments.ToList());
        return result;
    }
}

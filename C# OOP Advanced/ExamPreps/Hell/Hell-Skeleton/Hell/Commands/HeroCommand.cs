using System.Collections.Generic;
using System.Linq;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(IList<string> arguments, IHeroManager heroMenager)
        : base(arguments, heroMenager)
    {
    }

    public override string Execute()
    {
        var result = this.HeroMenager.AddHero(this.Arguments.ToList());
        return result;
    }
}

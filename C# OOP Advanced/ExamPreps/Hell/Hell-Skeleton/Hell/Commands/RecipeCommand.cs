using System.Collections.Generic;
using System.Linq;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(IList<string> arguments, IHeroManager heroMenager)
        : base(arguments, heroMenager)
    {
    }

    public override string Execute()
    {
        string result = this.HeroMenager.AddRecipeToHero(this.Arguments.ToList());
        return result;
    }
}

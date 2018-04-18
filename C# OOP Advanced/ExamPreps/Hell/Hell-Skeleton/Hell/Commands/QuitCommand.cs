using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    protected QuitCommand(IList<string> arguments, IHeroManager heroMenager)
        : base(arguments, heroMenager)
    {
    }

    public override string Execute()
    {
        var result = this.HeroMenager.Quit();
        return result;
    }
}
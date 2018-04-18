using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    private IList<string> arguments;
    private IHeroManager heroMenager;

    protected AbstractCommand(IList<string> arguments, IHeroManager heroMenager)
    {
        this.Arguments = arguments;
        this.HeroMenager = heroMenager;
    }

    public IList<string> Arguments
    {
        get => arguments;
        private set => arguments = value;
    }

    public IHeroManager HeroMenager
    {
        get => heroMenager;
        private set => heroMenager = value;
    }

    public abstract string Execute();
}

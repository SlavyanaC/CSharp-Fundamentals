using System;
using System.Collections.Generic;

public interface IHeroManager
{
    string AddHero(IList<String> arguments);

    string AddItemToHero(IList<String> arguments);

    string AddRecipeToHero(IList<string> arguments);

    string Inspect(IList<String> arguments);

    string Quit();
}

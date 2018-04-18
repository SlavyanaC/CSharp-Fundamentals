using System.Collections.Generic;
using System.Linq;

class RecipeItem : AbstracItem, IRecipe
{
    private IList<string> requiredItems;

    public RecipeItem(string name, int strenghtBonus, int agilityBonus, int inteligenceBonus, int hitpointsBonus, int demageBonus, IList<string> requiredItems)
        : base(name, strenghtBonus, agilityBonus, inteligenceBonus, hitpointsBonus, demageBonus)
    {
        this.requiredItems = requiredItems;
    }

    public IReadOnlyList<string> RequiredItems
    {
        get => this.requiredItems.ToList();
    }
}


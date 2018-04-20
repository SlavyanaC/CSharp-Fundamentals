using System.Collections.Generic;
using System.Linq;

public class RecipeItem : AbstracItem, IRecipe
{
    private IList<string> requiredItems;

    public RecipeItem(string name, long strenghtBonus, long agilityBonus, long inteligenceBonus, long hitpointsBonus, long demageBonus, IList<string> requiredItems)
        : base(name, strenghtBonus, agilityBonus, inteligenceBonus, hitpointsBonus, demageBonus)
    {
        this.requiredItems = requiredItems;
    }

    public IReadOnlyList<string> RequiredItems
    {
        get => this.requiredItems.ToList();
    }
}


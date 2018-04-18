using System.Collections.Generic;
using System.Linq;

public class HeroInventory : IInventory
{
    [Item]
    private IDictionary<string, IItem> commonItems;
    private IDictionary<string, IRecipe> recipeItems;

    public HeroInventory()
    {
        this.commonItems = new Dictionary<string, IItem>();
        this.recipeItems = new Dictionary<string, IRecipe>();
    }

    public long TotalStrengthBonus => this.commonItems.Values.Sum(i => i.StrengthBonus);

    public long TotalAgilityBonus => this.commonItems.Values.Sum(i => i.AgilityBonus);

    public long TotalIntelligenceBonus => this.commonItems.Values.Sum(i => i.IntelligenceBonus);

    public long TotalHitPointsBonus => this.commonItems.Values.Sum(i => i.HitPointsBonus);

    public long TotalDamageBonus => this.commonItems.Values.Sum(i => i.DamageBonus);

    public void AddCommonItem(IItem item)
    {
        this.commonItems.Add(item.Name, item);
        this.CheckRecipes();
    }

    public void AddRecipeItem(IRecipe reciepe)
    {
        this.recipeItems.Add(reciepe.Name, reciepe);
        this.CheckRecipes();
    }

    private void CheckRecipes()
    {
        foreach (IRecipe recipe in this.recipeItems.Values)
        {
            IList<string> requiredItems = new List<string>(recipe.RequiredItems);

            foreach (IItem commonItem in this.commonItems.Values)
            {
                if (requiredItems.Contains(commonItem.Name))
                {
                    requiredItems.Remove(commonItem.Name);
                }
            }

            if (requiredItems.Count == 0)
            {
                this.CombineRecipe(recipe);
            }
        }
    }

    private void CombineRecipe(IRecipe recipe)
    {
        for (int i = 0; i < recipe.RequiredItems.Count; i++)
        {
            string item = recipe.RequiredItems[i];
            this.commonItems.Remove(item);
        }

        IItem newItem = new CommonItem(recipe.Name,
            recipe.StrengthBonus,
            recipe.AgilityBonus,
            recipe.IntelligenceBonus,
            recipe.HitPointsBonus,
            recipe.DamageBonus);

        this.commonItems.Add(newItem.Name, newItem);
    }
}
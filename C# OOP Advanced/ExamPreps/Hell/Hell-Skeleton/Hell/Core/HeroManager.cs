using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IHeroManager
{
    IList<IHero> heroes;

    public HeroManager()
    {
        this.heroes = new List<IHero>();
    }

    public string AddHero(IList<string> arguments)
    {
        string heroName = arguments[0];
        string heroType = arguments[1];

        Type enetityType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(heroType, StringComparison.OrdinalIgnoreCase));

        IHero hero = (IHero)Activator.CreateInstance(enetityType, heroName);

        this.heroes.Add(hero);
        string result = string.Format(Constants.HeroCreateMessage, heroType, hero.Name);

        return result;
    }

    public string AddItemToHero(IList<string> arguments)
    {
        string heroName = arguments[1];
        IItem item = CreateItem(arguments);
        IHero hero = FindHero(heroName);

        hero.AddItem(item);

        var result = string.Format(Constants.ItemCreateMessage, item.Name, heroName);
        return result;
    }

    private IItem CreateItem(IList<string> arguments)
    {
        string itemName = arguments[0];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        Type entityType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(nameof(CommonItem), StringComparison.OrdinalIgnoreCase));

        object[] ctorParams = new object[] { itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus };

        IItem item = (IItem)Activator.CreateInstance(entityType, ctorParams);

        return item;
    }

    public string AddRecipeToHero(IList<string> arguments)
    {
        string heroName = arguments[1];
        IRecipe recipe = CreateRecipe(arguments);
        IHero hero = FindHero(heroName);

        hero.AddRecipe(recipe);
        var result = string.Format(Constants.RecipeCreatedMessage, recipe.Name, heroName);
        return result;
    }

    private IRecipe CreateRecipe(IList<string> arguments)
    {
        string recipeName = arguments[0];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        string[] reqiredItem = arguments.Skip(7).ToArray();

        Type entityType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(nameof(RecipeItem), StringComparison.OrdinalIgnoreCase));

        object[] ctorParams = new object[] { recipeName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus , reqiredItem};

        IRecipe recipe = (IRecipe)Activator.CreateInstance(entityType, ctorParams);

        return recipe;
    }

    private IHero FindHero(string heroName)
    {
        IHero wantedHero = this.heroes.FirstOrDefault(h => h.Name.Equals(heroName, StringComparison.OrdinalIgnoreCase));

        if (wantedHero == null)
        {
            throw new ArgumentException(string.Format(Constants.InvalidHeroExceptionMessage, heroName));
        }

        return wantedHero;
    }

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes
            .FirstOrDefault(h => h.Name.Equals(heroName, StringComparison.OrdinalIgnoreCase))
            .ToString();
    }

    public string Quit()
    {
        StringBuilder builder = new StringBuilder();

        int counter = 0;
        foreach (IHero hero in this.heroes.OrderByDescending(h => h.PrimaryStats)
                                          .ThenByDescending(h => h.SecondaryStats))
        {
            builder.AppendLine($"{++counter}. {hero.GetType().Name}: {hero.Name}")
                   .AppendLine($"###HitPoints: {hero.HitPoints}")
                   .AppendLine($"###Damage: {hero.Damage}")
                   .AppendLine($"###Strength: {hero.Strength}")
                   .AppendLine($"###Agility: {hero.Agility}")
                   .AppendLine($"###Intelligence: {hero.Intelligence}");

            if (hero.Items.Count > 0)
            {
                builder.AppendLine($"###Items: {string.Join(", ", hero.Items.Select(i => i.Name))}");
            }
            else
            {
                builder.AppendLine($"###{Constants.NoItemsMessage}");
            }
        }

        return builder.ToString().Trim();
    }
}
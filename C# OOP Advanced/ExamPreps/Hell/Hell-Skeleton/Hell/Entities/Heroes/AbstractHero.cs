using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero
{
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;
    private IInventory inventory;

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats => this.Strength + this.Agility + this.Intelligence;

    public long SecondaryStats => this.HitPoints + this.Damage;

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            FieldInfo commonItemsFromInventory = this.inventory.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name.Equals($"{nameof(CommonItem)}s", StringComparison.OrdinalIgnoreCase));

            IDictionary<string, IItem> itemsFromInventory = (IDictionary<string, IItem>)commonItemsFromInventory
                .GetValue(this.inventory);

            return itemsFromInventory
                .Select(kvp => kvp.Value)
                .ToArray();
        }
    }

    public void AddItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}")
               .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
               .AppendLine($"Strength: {this.Strength}")
               .AppendLine($"Agility: {this.Agility}")
               .AppendLine($"Intelligence: {this.Intelligence}");

        if (this.Items.Count > 0)
        {
            builder.AppendLine($"Items:");
            foreach (IItem item in this.Items)
            {
                builder.AppendLine(item.ToString());
            }
        }
        else
        {
            builder.AppendLine(Constants.NoItemsMessage);
        }

        return builder.ToString().Trim();
    }
}
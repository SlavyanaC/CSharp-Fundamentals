using System.Text;

public abstract class AbstracItem : IItem
{
    protected AbstracItem(string name, long strenghtBonus, long agilityBonus, long inteligenceBonus, long hitpointsBonus, long demageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strenghtBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = inteligenceBonus;
        this.HitPointsBonus = hitpointsBonus;
        this.DamageBonus = demageBonus;
    }

    public string Name { get; }

    public long StrengthBonus { get; }

    public long AgilityBonus { get; }

    public long IntelligenceBonus { get; }

    public long HitPointsBonus { get; }

    public long DamageBonus { get; }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"###Item: {this.Name}")
               .AppendLine($"###+{this.StrengthBonus} Strength")
               .AppendLine($"###+{this.AgilityBonus} Agility")
               .AppendLine($"###+{this.IntelligenceBonus} Intelligence")
               .AppendLine($"###+{this.HitPointsBonus} HitPoints")
               .AppendLine($"###+{this.DamageBonus} Damage");

        return builder.ToString().Trim();
    }
}

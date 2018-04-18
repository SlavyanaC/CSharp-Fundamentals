using System.Text;

public abstract class AbstracItem : IItem
{
    protected AbstracItem(string name, int strenghtBonus, int agilityBonus, int inteligenceBonus, int hitpointsBonus, int demageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strenghtBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = inteligenceBonus;
        this.HitPointsBonus = hitpointsBonus;
        this.DamageBonus = demageBonus;
    }

    public string Name { get; }

    public int StrengthBonus { get; }

    public int AgilityBonus { get; }

    public int IntelligenceBonus { get; }

    public int HitPointsBonus { get; }

    public int DamageBonus { get; }

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

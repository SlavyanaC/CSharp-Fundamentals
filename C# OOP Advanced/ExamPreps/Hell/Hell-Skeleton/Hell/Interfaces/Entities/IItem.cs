public interface IItem
{
    long StrengthBonus { get; }
    
    long AgilityBonus { get; }
    
    long IntelligenceBonus { get; }
    
    long HitPointsBonus { get; }
    
    long DamageBonus { get; }

    string Name { get; }
}

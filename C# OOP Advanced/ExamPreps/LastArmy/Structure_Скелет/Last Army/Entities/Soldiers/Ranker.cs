using System;
using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMultiplier = 1.5;

    private readonly List<string> weaponsAllowed = new List<string>()
    {
        nameof(AutomaticMachine),
        nameof(Gun),
        nameof(Helmet),
    };
    
    public Ranker(string name, int age, double expirience, double endurance)
        : base(name, age, expirience, endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMultiplier;

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;
}

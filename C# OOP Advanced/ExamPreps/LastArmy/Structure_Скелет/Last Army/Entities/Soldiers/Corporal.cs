using System;
using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMultiplier = 2.5;

    private readonly List<string> weaponsAllowed = new List<string>()
    { 
        nameof(AutomaticMachine),
        nameof(Gun),
        nameof(Helmet),
        nameof(Knife),
        nameof(MachineGun),
    };

    public Corporal(string name, int age, double expirience, double endurance) 
        : base(name, age, expirience, endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMultiplier;

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;
}

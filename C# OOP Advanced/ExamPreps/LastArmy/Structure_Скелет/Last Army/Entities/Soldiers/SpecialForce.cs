using System.Collections.Generic;


public class SpecialForce : Soldier
{
    private const int SpecialRegenerationValue = 30;
    private const double OverallSkillMiltiplier = 3.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(AutomaticMachine),
            nameof(Gun),
            nameof(Helmet),
            nameof(Knife),
            nameof(MachineGun),
            nameof(NightVision),
            nameof(RPG),
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override void Regenerate()
    {
        this.Endurance += this.Age + SpecialRegenerationValue;
    }
}

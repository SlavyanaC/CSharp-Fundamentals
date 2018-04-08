using System;

public class Warrior : AbstractHero
{
    private const string ATTACK_MESSAGE = "{0} damages {1} for {2}";

    public Warrior(string id, int damage, IHandler handler) 
        : base(id, damage, handler)
    {
    }

    protected override void ExecuteClassSpecificAttack(ITarget target, int damage)
    {
        Console.WriteLine(ATTACK_MESSAGE, this, target, damage);
    }
}

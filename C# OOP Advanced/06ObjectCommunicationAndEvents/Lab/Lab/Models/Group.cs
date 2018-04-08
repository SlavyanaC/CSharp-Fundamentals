using System.Collections.Generic;

public class Group : IAttackGroup
{
    private IList<IAttacker> attackers;

    public Group()
    {
        this.attackers = new List<IAttacker>();
    }

    public void AddMember(IAttacker attacker)
    {
        this.attackers.Add(attacker);
    }

    public void GroupAttack()
    {
        foreach (var attacker in this.attackers)
        {
            attacker.Attack();
        }
    }

    public void GroupTarget(ITarget target)
    {
        foreach (var attacker in this.attackers)
        {
            attacker.SetTarget(target);
        }
    }

    public void GroupTargetAndAttacke(ITarget target)
    {
        this.GroupAttack();
        this.GroupTarget(target);
    }
}

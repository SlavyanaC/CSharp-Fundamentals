namespace Object_Communication_and_Events_Lab
{
    class StartUp
    {
        static void Main()
        {
            Logger combatLog = new CombatLogger();
            Logger eventLog = new EventLogger();

            IAttackGroup attackGroup = new Group();

            attackGroup.AddMember(new Warrior("Torsten", 10, combatLog));
            attackGroup.AddMember(new Warrior("Rolo", 15, combatLog));

            ITarget target = new Dragon("Transylvanian White", 200, 25, combatLog);

            IExecutor executor = new CommandExecutor();

            ICommand groupTarget = new GroupTargetCommand(attackGroup, target);
            ICommand groupAttack = new GroupAttackCommand(attackGroup);
        }
    }
}

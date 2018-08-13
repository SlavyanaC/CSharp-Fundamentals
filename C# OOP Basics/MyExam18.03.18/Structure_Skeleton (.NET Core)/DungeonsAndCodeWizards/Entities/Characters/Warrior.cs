using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const int InitialBaseHealt = 100;
        private const int InitialBaseArmor = 50;
        private const int InitialAbilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, InitialBaseHealt, InitialBaseArmor, InitialAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(Output.AttackSelf);
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(Output.FriendlyFire, this.Faction));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}

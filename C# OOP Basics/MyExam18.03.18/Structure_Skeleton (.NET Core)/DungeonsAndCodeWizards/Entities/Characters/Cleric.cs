using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        private const int InitialBaseHealt = 50;
        private const int InitialBaseArmor = 25;
        private const int InitialAbilityPoints = 40;

        public Cleric(string name, Faction faction)
            : base(name, InitialBaseHealt, InitialBaseArmor, InitialAbilityPoints, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(Output.InvalidHeal);
            }

            character.TakeHeal(this.AbilityPoints);
        }
    }
}

using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
        private const int PoisonPotionWeight = 5;

        public PoisonPotion() 
            : base(PoisonPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.UseItem(this);
        }
    }
}

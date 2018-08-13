using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int HealthPotionWeight = 5;

        public HealthPotion()
            : base(HealthPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.UseItem(this);
        }
    }
}

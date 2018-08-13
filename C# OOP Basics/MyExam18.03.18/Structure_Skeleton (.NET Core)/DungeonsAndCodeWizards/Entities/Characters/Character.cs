using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Items;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private const double DefaultRestHealMultiplier = 0.2;

        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;

            this.IsAlive = true;
            this.RestHealMultiplier = DefaultRestHealMultiplier;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Output.InvalidName);
                }
                name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health { get; protected set; }

        public double BaseArmor { get; }

        public double Armor { get; protected set; }

        public double AbilityPoints { get; }

        public Bag Bag { get; protected set; }

        public Faction Faction { get; }

        public bool IsAlive { get; protected set; }

        public virtual double RestHealMultiplier { get; protected set; }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (this.Armor > hitPoints)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                var reminder = Math.Abs(this.Armor - hitPoints);
                this.Armor -= (hitPoints - reminder);
                this.Health -= reminder;
                this.Health = this.Health < 0 ? 0 : this.Health;

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void TakeHeal(double healPoints)
        {
            this.EnsureAlive();
            this.Health += healPoints;
            this.Health = this.Health > this.BaseHealth ? this.BaseHealth : this.Health;
        }

        public void Rest()
        {
            this.EnsureAlive();
            this.Health += this.BaseHealth * this.RestHealMultiplier;
            this.Health = this.Health > this.BaseHealth ? this.BaseHealth : this.Health;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            string itemType = item.GetType().Name;
            switch (itemType)
            {
                case "ArmorRepairKit":
                    this.Armor = this.BaseArmor;
                    break;
                case "HealthPotion":
                    this.Health += 20;
                    this.Health = this.Health > this.BaseHealth ? this.BaseHealth : this.Health;
                    break;
                case "PoisonPotion":
                    this.Health -= 20;
                    this.Health = this.Health < 0 ? 0 : this.Health;
                    break;
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            character.UseItem(item);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.EnsureAlive();
            this.Bag.AddItem(item);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            string status = this.IsAlive ? "Alive" : "Dead";
            var result = $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
            return result;
        }
    }
}


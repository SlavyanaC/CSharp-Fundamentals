using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Characters.Factory.CharacterFactory;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Entities.Items.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        private IList<Character> characterParty;
        private IList<Item> itemPool;

        private int lastSurviverRounds;

        public DungeonMaster()
        {
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.characterParty = new List<Character>();
            this.itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            if (faction != Faction.CSharp.ToString() && faction != Faction.Java.ToString())
            {
                throw new ArgumentException(string.Format(Output.InvalidFaction, faction));
            }

            Character character = this.characterFactory.CreateCharacter(faction, characterType, name);

            this.characterParty.Add(character);

            return string.Format(Output.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = this.itemFactory.CreateItem(itemName);
            this.itemPool.Add(item);
            return string.Format(Output.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.characterParty.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(Output.CharacterNotFound, characterName));
            }
            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(Output.EmptyPool);
            }

            Item item = this.itemPool.Last();
            this.itemPool.RemoveAt(this.itemPool.Count - 1);
            character.Bag.AddItem(item);

            return string.Format(Output.SuccsessfulPickUp, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characterParty.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new InvalidOperationException(string.Format(Output.CharacterNotFound, characterName));
            }

            if (character.Bag.Items.Count == 0)
            {
                throw new InvalidOperationException(Output.EmptyBag);
            }
            Item item = character.Bag.Items.FirstOrDefault(i => i.GetType().Name == itemName);
            if (item == null)
            {
                throw new ArgumentException(string.Format(Output.NoItemInBag, itemName)); ;
            }
            character.UseItem(item);

            return string.Format(Output.UseItem, characterName, itemName);
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.characterParty.FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(Output.CharacterNotFound, giverName));
            }

            Character receiver = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Output.CharacterNotFound, receiverName));
            }

            Item item = giver.Bag.Items.FirstOrDefault(i => i.GetType().Name == itemName);
            giver.UseItemOn(item, receiver);

            return string.Format(Output.UseItemOn, giverName, itemName, receiverName);
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.characterParty.FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(Output.CharacterNotFound, giverName));
            }

            Character receiver = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Output.CharacterNotFound, receiverName));
            }

            Item item = giver.Bag.Items.FirstOrDefault(i => i.GetType().Name == itemName);
            giver.GiveCharacterItem(item, receiver);

            return string.Format(Output.GiveCharItem, giverName, receiverName, itemName);
        }

        public string GetStats()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Character character in this.characterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                builder.AppendLine(character.ToString());
            }

            return builder.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.characterParty.FirstOrDefault(c => c.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(Output.CharacterNotFound, attackerName));
            }

            Character receiver = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Output.CharacterNotFound, receiverName));
            }

            if (!(attacker is IAttackable attackable))
            {
                throw new ArgumentException(string.Format(Output.CannotAttack, attackerName));
            }

            attackable.Attack(receiver);

            var result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + $"{receiver.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = this.characterParty.FirstOrDefault(c => c.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(Output.CharacterNotFound, healerName));
            }

            Character receiver = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Output.CharacterNotFound, receiverName));
            }

            if (!(healer is IHealable healable))
            {
                throw new ArgumentException(string.Format(Output.CannotHeal, healerName));
            }

            healable.Heal(receiver);

            var result = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            StringBuilder builder = new StringBuilder();

            var aliveCharacters = this.characterParty.Where(c => c.IsAlive).ToArray();
            foreach (Character character in this.characterParty.Where(c => c.IsAlive == true))
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                builder.AppendLine(string.Format(Output.CharacterRest, character.Name, healthBeforeRest, character.Health));
            }

            if (aliveCharacters.Length <= 1)
            {
                this.lastSurviverRounds++;
            }

            return builder.ToString().Trim();
        }

        public bool IsGameOver()
        {
            var aliveCharacters = this.characterParty.Where(c => c.IsAlive).ToArray();

            bool oneSurviver = aliveCharacters.Length <= 1;
            bool lastSurviverPlaysAlone = this.lastSurviverRounds > 1;

            return oneSurviver && lastSurviverPlaysAlone;
        }
    }
}

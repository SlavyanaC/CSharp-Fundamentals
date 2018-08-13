using DungeonsAndCodeWizards.Constants;
using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Entities.Characters.Factory.CharacterFactory
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionAsString, string type, string name)
        {
            Type characterType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (characterType == null)
            {
                throw new ArgumentException(string.Format(Output.InvalidCharacterType, type));
            }
            if (!typeof(Character).IsAssignableFrom(characterType))
            {
                throw new ArgumentException(string.Format(Output.InvalidCharacterType, type));
            }

            object faction;
            Enum.TryParse(typeof(Faction), factionAsString, out faction);
            Character character = (Character)Activator.CreateInstance(characterType, name, faction);

            return character;
        }
    }
}

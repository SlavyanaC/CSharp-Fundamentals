namespace DungeonsAndCodeWizards.Constants
{
    public static class Output
    {
        public const string CharacterDeadIOE = "Must be alive to perform this action!";

        public const string FullBag = "Bag is full!";

        public const string EmptyBag = "Bag is empty!";

        public const string NoItemInBag = "No item with name {0} in bag!";

        public const string InvalidName = "Name cannot be null or whitespace!";

        public const string AttackSelf = "Cannot attack self!";

        public const string FriendlyFire = "Friendly fire! Both characters are from {0} faction!";

        public const string InvalidHeal = "Cannot heal enemy character!";

        public const string InvalidFaction = @"Invalid faction ""{0}""!";

        public const string InvalidCharacterType = @"Invalid character type ""{0}""!";

        public const string JoinParty = "{0} joined the party!";

        public const string InvalidItemType = @"Invalid item ""{0}""!";

        public const string AddItemToPool = "{0} added to pool.";

        public const string EndTurnCommand = "EndTurn";

        public const string CharacterNotFound = "Character {0} not found!";

        public const string EmptyPool = "No items left in pool!";

        public const string SuccsessfulPickUp = "{0} picked up {1}!";

        public const string UseItem = "{0} used {1}.";

        public const string UseItemOn = "{0} used {1} on {2}.";

        public const string GiveCharItem = "{0} gave {1} {2}.";

        public const string CannotAttack = "{0} cannot attack!";

        public const string CannotHeal = "{0} cannot heal!";

        public const string CharacterRest = "{0} rests ({1} => {2})";
    }
}

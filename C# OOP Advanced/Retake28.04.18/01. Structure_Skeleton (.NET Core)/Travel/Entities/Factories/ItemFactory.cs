namespace Travel.Entities.Factories
{
    using Contracts;
    using Items;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using Travel.Core;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string type)
        {
            Type itemType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (itemType == null)
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidType, type));
            }

            if (!typeof(IItem).IsAssignableFrom(itemType))
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidAssignment, type, "item"));
            }

            IItem item = (IItem)Activator.CreateInstance(itemType, null);
            return item;
        }
    }
}

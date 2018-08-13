using DungeonsAndCodeWizards.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Items.Factory
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            Type itemType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == itemName);

            if (itemType == null)
            {
                throw new ArgumentException(string.Format(Output.InvalidItemType, itemName));
            }
            if (!typeof(Item).IsAssignableFrom(itemType))
            {
                throw new ArgumentException(string.Format(Output.InvalidItemType, itemName));
            }

            Item item = (Item)Activator.CreateInstance(itemType, null);

            return item;
        }
    }
}

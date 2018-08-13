using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        private const int DefaultCapacity = 100;
        private ICollection<Item> items;

        protected Bag(int capacity)
        {
            this.items = new List<Item>();
            this.Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items.ToList();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(Output.FullBag);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(Output.EmptyBag);
            }

            Item item = this.Items.FirstOrDefault(i => i.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(string.Format(Output.NoItemInBag, name));
            }

            this.items.Remove(item);
            return item;
        }
    }
}

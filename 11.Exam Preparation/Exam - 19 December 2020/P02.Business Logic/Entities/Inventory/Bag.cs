namespace WarCroft.Entities.Inventory
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using WarCroft.Constants;
    using WarCroft.Entities.Items;

    public abstract class Bag : IBag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(item);
            return item;
        }
    }
}

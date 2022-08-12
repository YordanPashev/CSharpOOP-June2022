namespace SpaceStation.Models.Bags
{

    using SpaceStation.Models.Bags.Contracts;
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        private List<string> item;

        public Backpack()
        {
            item = new List<string>();
        }

        public ICollection<string> Items => this.item;
    }
}

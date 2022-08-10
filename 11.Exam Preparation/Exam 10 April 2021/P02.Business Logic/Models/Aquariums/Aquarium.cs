namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
            => decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (Capacity <= 0)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.fish.Add(fish);
            Capacity--;
        }

        public void Feed()
        {
            foreach (IFish currFish in fish)
            {
                currFish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder aquariumInfo = new StringBuilder();

            aquariumInfo.AppendLine($"{this.Name} ({this.GetType().Name}):")
                        .AppendLine(this.fish.Any() ? "Fish: none"
                                               : $"Fish: {string.Join(", ", this.fish.Select(f => f.Name))}")
                        .AppendLine($"Decorations: {this.decorations.Count()}")
                        .AppendLine($"Comfort: {this.Comfort}");

            return aquariumInfo.ToString().TrimEnd();
        }


        public bool RemoveFish(IFish fish)
            => this.fish.Remove(fish);
    }
}

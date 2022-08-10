namespace AquaShop.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using AquaShop.Models.Fish;
    using AquaShop.Repositories;
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Utilities.Messages;
    using AquaShop.Models.Decorations;
    using AquaShop.Repositories.Contracts;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;

    internal class Controller : IController 
    {
        private IRepository<IDecoration> decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = aquariumType switch
            {
                nameof(FreshwaterAquarium) => new FreshwaterAquarium(aquariumName),
                nameof(SaltwaterAquarium) => new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType)
            };

            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = decorationType switch
            {
                nameof(Plant) => new Plant(),
                nameof(Ornament) => new Ornament(),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType)
            };

            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish = fishType switch
            {
                nameof(FreshwaterFish) => new FreshwaterFish(fishName, fishSpecies, price),
                nameof(SaltwaterFish) => new SaltwaterFish(fishName, fishSpecies, price),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidFishType)
            };

            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (fish.AquariumType != aquarium.GetType().Name)
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal sumOfAllFishes = aquarium.Fish.Sum(f => f.Price);
            decimal sumOfAllDecorations = aquarium.Decorations.Sum(d => d.Price);
            decimal totalPrice = sumOfAllDecorations + sumOfAllFishes;

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalPrice);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            foreach (Fish fish in aquarium.Fish)
            {
                fish.Eat();
            }

            int fededFishes = aquarium.Fish.Count();
            return string.Format(OutputMessages.FishFed, fededFishes);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder reportResult = new StringBuilder();

            foreach (IAquarium aquarium in aquariums)
            {
                reportResult.AppendLine($"{aquarium.Name} ({aquarium.GetType().Name}):")
                            .AppendLine($"Fish: {string.Format(!aquarium.Fish.Any() ? "none" : string.Join(", ", aquarium.Fish.Select(f => f.Name)))}")
                            .AppendLine($"Decorations: {aquarium.Decorations.Count()}")
                            .AppendLine($"Comfort: {aquarium.Comfort}");
            }

            return reportResult.ToString().TrimEnd();
        }
    }
}

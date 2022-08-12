namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;

    using SpaceStation.Utilities.Messages;
    using SpaceStation.Models.Planets.Contracts;

    internal class Planet : IPlanet
    {
        private string name;
        private ICollection<string> items;

        public Planet(string name)
        {
            Name = name;
            items = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public ICollection<string> Items => this.items;
    }
}

namespace PlanetWars.Repositories
{

    using System.Linq;

    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using System.Collections.Generic;

    internal class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void AddItem(IPlanet model) => this.models.Add(model);

        public IPlanet FindByName(string name)
            => models.FirstOrDefault(p => p.Name == name);

        public bool RemoveItem(string name)
        {
            IPlanet planet = FindByName(name);
            return models.Remove(planet);
        }
    }
}

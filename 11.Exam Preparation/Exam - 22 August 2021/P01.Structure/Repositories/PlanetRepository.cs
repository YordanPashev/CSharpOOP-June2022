namespace SpaceStation.Repositories
{

    using System.Linq;

    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System.Collections.Generic;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model) => this.models.Add(model);

        public IPlanet FindByName(string name)
            => this.models.FirstOrDefault(a => a.Name == name);

        public bool Remove(IPlanet model) => this.models.Remove(model);
    }
}

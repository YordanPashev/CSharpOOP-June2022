namespace SpaceStation.Repositories
{

    using System.Linq;
    using System.Collections.Generic;

    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model) => this.models.Add(model);

        public IAstronaut FindByName(string name) 
            => this.models.FirstOrDefault(a => a.Name == name);

        public bool Remove(IAstronaut model) => this.models.Remove(model);
    }
}

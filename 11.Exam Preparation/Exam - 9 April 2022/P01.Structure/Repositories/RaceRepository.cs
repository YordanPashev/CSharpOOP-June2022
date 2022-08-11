namespace Formula1.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;

    internal class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.models.AsReadOnly();

        public void Add(IRace model)
            => this.models.Add(model);

        public IRace FindByName(string name)
            => this.models.FirstOrDefault(r => r.RaceName == name);

        public bool Remove(IRace model)
            => models.Remove(model);
    }
}

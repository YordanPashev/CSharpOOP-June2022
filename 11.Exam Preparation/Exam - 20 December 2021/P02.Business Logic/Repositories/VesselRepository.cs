namespace NavalVessels.Repositories
{

    using System.Linq;

    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;
    using System.Collections.Generic;

    internal class VesselRepository : IRepository<IVessel>
    {
        private HashSet<IVessel> models;

        public VesselRepository()
        {
            models = new HashSet<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => this.models;

        public void Add(IVessel model) => this.models.Add(model);

        public IVessel FindByName(string name) => this.models.FirstOrDefault(v => v.Name == name);

        public bool Remove(IVessel model) => this.models.Remove(model);
    }
}

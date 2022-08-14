namespace PlanetWars.Repositories
{

    using System.Linq;
    using System.Collections.Generic;

    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;


    internal class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => models.AsReadOnly();

        public void AddItem(IMilitaryUnit model) => models.Add(model);

        public IMilitaryUnit FindByName(string name)
            => models.FirstOrDefault(u => u.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unit = FindByName(name);
            return models.Remove(unit);
        }
    }
}

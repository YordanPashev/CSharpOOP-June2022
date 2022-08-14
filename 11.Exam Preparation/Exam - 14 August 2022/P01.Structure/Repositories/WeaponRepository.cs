namespace PlanetWars.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models.AsReadOnly();

        public void AddItem(IWeapon model) => models.Add(model);

        public IWeapon FindByName(string name) 
            => models.FirstOrDefault(w => w.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IWeapon weapon = FindByName(name);
            return models.Remove(weapon);
        }

    }
}

using System.Linq;
using System.Collections.Generic;

using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        public void Add(IWeapon model) => weapons.Add(model);

        public IWeapon FindByName(string name) =>
            weapons.FirstOrDefault(h => h.Name == name);

        public bool Remove(IWeapon model)
            => weapons.Remove(model);
    }
}

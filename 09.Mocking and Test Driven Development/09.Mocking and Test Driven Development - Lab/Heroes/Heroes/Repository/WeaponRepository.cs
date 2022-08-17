namespace Heroes.Repository
{
    using System.Linq;
    using System.Collections.Generic;

    using Heroes.Models.Contracts;
    using Heroes.Repository.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private HashSet<IWeapon> models;

        public WeaponRepository()
        {
            models = new HashSet<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models;

        public void AddItem(IWeapon model) => models.Add(model);

        public IWeapon FindByName(string attackPoints)
        => this.models.FirstOrDefault(h => h.AttackPoints == int.Parse(attackPoints));

        public bool RemoveItem(string name) => this.RemoveItem(name);
    }
}

using System.Linq;
using System.Collections.Generic;

using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.heroes;

        public void Add(IHero model) => heroes.Add(model);

        public IHero FindByName(string name) =>
            heroes.FirstOrDefault(h => h.Name == name);

        public bool Remove(IHero model)
            => heroes.Remove(model);
    }
}

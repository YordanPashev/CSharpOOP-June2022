namespace Heroes.Repository
{

    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using Heroes.Models.Contracts;
    using Heroes.Repository.Contracts;
    using System.Text;

    public class HeroRepository : IRepository<IHero>
    {
        private HashSet<IHero> models;

        public HeroRepository()
        {
            models = new HashSet<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.models;

        public virtual void AddItem(IHero model)
        {
            models.Add(model);
            File.AppendAllText(@"C:\Users\pashe\source\repos\Heroes\Heroes\heroesDatabase.txt", model.ToString() + Environment.NewLine);
        }

        public IHero FindByName(string name) => this.models.FirstOrDefault(h => h.Name == name);

        public bool RemoveItem(string name)
        {
            StringBuilder result = new StringBuilder();
            foreach (var hero in models)
            {
                if (hero.Name == name)
                {
                    continue;
                }
                result.AppendLine(hero.ToString().TrimEnd());

            }
            File.WriteAllText(@"C:\Users\pashe\source\repos\Heroes\Heroes\heroesDatabase.txt", result.ToString().TrimEnd());  

            return this.RemoveItem(name);
        }

    }
}

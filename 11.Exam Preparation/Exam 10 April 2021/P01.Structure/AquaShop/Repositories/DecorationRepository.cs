namespace AquaShop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using AquaShop.Repositories.Contracts;
    using AquaShop.Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository() 
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models;

        public void Add(IDecoration model)
            => this.models.Add(model);

        public IDecoration FindByType(string type)
            => models.FirstOrDefault(m => m.GetType().Name == type);

        public bool Remove(IDecoration model)
            => models.Remove(model);
    }
}

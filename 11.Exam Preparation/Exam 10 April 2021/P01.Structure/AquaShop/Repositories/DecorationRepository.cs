namespace AquaShop.Repositories
{
    using System.Linq;

    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System.Collections.Generic;

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

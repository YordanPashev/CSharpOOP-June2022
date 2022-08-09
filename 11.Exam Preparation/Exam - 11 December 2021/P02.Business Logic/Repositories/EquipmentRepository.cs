namespace Gym.Repositories
{

    using System.Linq;
    using System.Collections.Generic;

    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models = new List<IEquipment>();

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => models.AsReadOnly();


        public void Add(IEquipment model)
            =>models.Add(model);

        public IEquipment FindByType(string type)
            => models.FirstOrDefault(x => x.GetType().Name == type);

        public bool Remove(IEquipment model)
            => models.Remove(model);
    }
}

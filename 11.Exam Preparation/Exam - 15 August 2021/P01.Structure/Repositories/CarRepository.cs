namespace CarRacing.Repositories
{

    using System;
    using System.Linq;
    using System.Collections.Generic;

    using CarRacing.Utilities.Messages;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;

    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => this.models.AsReadOnly();

        public void Add(ICar model)
        {
            if(model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
        }

        public ICar FindBy(string property) => models.FirstOrDefault(c => c.VIN == property);

        public bool Remove(ICar model) => models.Remove(model);
    }
}

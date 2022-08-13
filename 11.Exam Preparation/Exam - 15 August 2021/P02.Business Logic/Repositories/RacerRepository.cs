namespace CarRacing.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using CarRacing.Repositories.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;

    internal class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => this.models.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            models.Add(model);
        }

        public IRacer FindBy(string property) => models.FirstOrDefault(r => r.Username == property);

        public bool Remove(IRacer model) => models.Remove(model);
    }
}

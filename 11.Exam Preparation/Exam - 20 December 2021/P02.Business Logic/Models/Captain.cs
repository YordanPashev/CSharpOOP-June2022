namespace NavalVessels.Models
{

    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;

    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.combatExperience = 0;
            vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }

                this.fullName = value;
            }
        }

        public int CombatExperience => this.combatExperience;

        public ICollection<IVessel> Vessels => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
            => this.combatExperience += 10;

        public string Report()
        {
            StringBuilder reportResult = new StringBuilder();
            reportResult.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {vessels.Count()} vessels.");

            if (this.vessels.Any())
            {
                reportResult.AppendLine(string.Join(Environment.NewLine, vessels));
            }

            return reportResult.ToString().TrimEnd();
        }
    }
}

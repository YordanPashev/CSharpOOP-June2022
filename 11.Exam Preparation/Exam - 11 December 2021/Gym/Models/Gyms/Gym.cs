using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> listOfTotalEquipment;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            listOfTotalEquipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => Equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => listOfTotalEquipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
            Capacity--;
        }

        public void AddEquipment(IEquipment equipment)
            => Equipment.Add(equipment);

        public void Exercise()
        {
            foreach (IAthlete athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Name} is a {this.GetType().Name}:");

            if (athletes.Count() == 0)
            {
                result.AppendLine($"Athletes: No athletes");
            }
            else
            {
                result.AppendLine($"Athletes: {string.Join(", ", athletes.Select(a => a.FullName))}");
            }

            result.AppendLine($"Equipment total count: {Equipment.Count()}");
            result.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return result.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
            => Athletes.Remove(athlete);
    }
}

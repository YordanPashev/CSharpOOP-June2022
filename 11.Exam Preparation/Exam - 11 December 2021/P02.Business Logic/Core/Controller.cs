namespace Gym.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Repositories;
    using Core.Contracts;
    using Models.Athletes;
    using Models.Equipment;
    using Models.Gyms.Contracts;
    using Repositories.Contracts;
    using Models.Athletes.Contracts;
    using Models.Equipment.Contracts;
    using Models.Gyms;

    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private ICollection<IGym> gym;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gym = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, 
                                 string motivation, int numberOfMedals)
        {
            IGym currGym = gym.FirstOrDefault(g => g.Name == gymName);

            IAthlete athlete = athleteType switch 
            { 
                nameof(Boxer) => new Boxer(athleteName, motivation,  numberOfMedals),
                nameof(Weightlifter) => new Weightlifter(athleteName, motivation, numberOfMedals),
                _ => throw new InvalidOperationException("Invalid athlete type.")
            };

            if(athleteType == "Boxer" && currGym.GetType().Name != "BoxingGym" ||
                athleteType == "Weightlifter" && currGym.GetType().Name != "WeightliftingGym")
            {
                return "The gym is not appropriate.";
            }

            currGym.AddAthlete(athlete);

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment pieceOfEquipment = equipmentType switch
            {
                nameof(BoxingGloves) => new BoxingGloves(),
                nameof(Kettlebell) => new Kettlebell(),
                _ => throw new InvalidOperationException("Invalid equipment type.")
            };

            equipment.Add(pieceOfEquipment);

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gymToBeAdded = gymType switch
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _ => throw new InvalidOperationException("Invalid gym type.")
            };

            gym.Add(gymToBeAdded);

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym currGym = gym.FirstOrDefault(g => g.Name == gymName);
            double totalWeight = currGym.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {totalWeight:F2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym currGym = gym.FirstOrDefault(g => g.Name == gymName);
            IEquipment pieceOfEquipment = equipment.FindByType(equipmentType);

            if (pieceOfEquipment == null)
            {
                throw new InvalidOperationException($"There isn't equipment of type {equipmentType}.");
            }

            currGym.AddEquipment(pieceOfEquipment);
            equipment.Remove(pieceOfEquipment);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder reportResult = new StringBuilder();

            foreach (IGym currGym in gym)
            {
                reportResult.AppendLine($"{currGym.Name} is a {currGym.GetType().Name}:")
                            .AppendLine(!currGym.Athletes.Any() ? "Athletes: No athletes"
                                                                : $"Athletes: {string.Join(", ", currGym.Athletes.Select(a => a.FullName))}")
                            .AppendLine($"Equipment total count: {currGym.Equipment.Count()}")
                            .AppendLine($"Equipment total weight: {currGym.EquipmentWeight:F2} grams");
            }

            return reportResult.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym currGym = gym.FirstOrDefault(g => g.Name == gymName);

            foreach (IAthlete athlete in currGym.Athletes)
            {
                athlete.Exercise();
            }

            int trainedAthletesCount = currGym.Athletes.Count();

            return $"Exercise athletes: {trainedAthletesCount}.";
        }
    }
}

namespace PlanetWars.Models.Planets
{

    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using PlanetWars.Repositories;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Utilities.Messages;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;

    public class Planet : IPlanet
    {
        private WeaponRepository weapons;
        private UnitRepository units;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            weapons = new WeaponRepository();
            units = new UnitRepository();      
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => CalculateTotalAmountOfMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit) => units.AddItem(unit);

        public void AddWeapon(IWeapon weapon) => weapons.AddItem(weapon);

        public string PlanetInfo()
        {
            StringBuilder planetInfo = new StringBuilder();

            string army = !Army.Any() ? "No units"
                                      : string.Join(", ", Army.Select(u => u.GetType().Name));

            string weapons = !Weapons.Any() ? "No weapons"
                                      : string.Join(", ", Weapons.Select(u => u.GetType().Name));

            planetInfo.AppendLine($"Planet: { this.Name}")
                      .AppendLine($"--Budget: {this.Budget} billion QUID")
                      .AppendLine($"--Forces: {army}")
                      .AppendLine($"--Combat equipment: {weapons}")
                      .AppendLine($"--Military Power: {this.MilitaryPower}");

            return planetInfo.ToString().TrimEnd();

        }

        public void Profit(double amount) => Budget += amount;

        public void Spend(double amount)
        {
            if (this.Budget - amount < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (IMilitaryUnit unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }

        private double CalculateTotalAmountOfMilitaryPower()
        {
            double totalAmount = Army.Sum(u => u.EnduranceLevel) + Weapons.Sum(w => w.DestructionLevel);

            if (Army.Any(w => w.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmount = totalAmount * 1.3;
            }

            if (Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmount = totalAmount * 1.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}

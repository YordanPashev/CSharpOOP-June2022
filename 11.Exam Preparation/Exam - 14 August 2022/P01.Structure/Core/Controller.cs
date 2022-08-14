﻿namespace PlanetWars.Core
{
    using PlanetWars.Repositories;
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Utilities.Messages;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using System;
    using System.Linq;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Models.Weapons;
    using System.Text;

    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit = unitTypeName switch
            {
                nameof(AnonymousImpactUnit) => new AnonymousImpactUnit(),
                nameof(SpaceForces) => new SpaceForces(),
                nameof(StormTroopers) => new StormTroopers(),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName))
            };

            planet.Spend(unit.Cost);

            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon = weaponTypeName switch
            {
                nameof(SpaceMissiles) => new SpaceMissiles(destructionLevel),
                nameof(NuclearWeapon) => new NuclearWeapon(destructionLevel),
                nameof(BioChemicalWeapon) => new BioChemicalWeapon(destructionLevel),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName))
            };

            planet.Spend(weapon.Price);

            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder reporstResult = new StringBuilder();
            reporstResult.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (IPlanet planet in planets.Models.OrderByDescending(p => p.MilitaryPower)
                                                     .ThenBy(p => p.Name))
            {
                reporstResult.AppendLine(planet.PlanetInfo());    
            }

            return reporstResult.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attacker = planets.FindByName(planetOne);
            IPlanet defender = planets.FindByName(planetTwo);
            string winner = string.Empty;
            string loser = string.Empty;

            if (attacker.MilitaryPower == defender.MilitaryPower)
            {
                if (attacker.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon) &&
                    !defender.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))))
                {
                    attacker.Spend(attacker.Budget / 2);
                    attacker.Profit(defender.Budget / 2);
                    attacker.Profit(defender.Army.Sum(u => u.Cost) + defender.Weapons.Sum(w => w.Price));

                    planets.RemoveItem(defender.Name);

                    winner = attacker.Name;
                    loser = defender.Name;

                    return string.Format(OutputMessages.WinnigTheWar, winner, loser);
                }

                if (!attacker.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon) &&
                    defender.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))))
                {
                    defender.Spend(defender.Budget / 2);
                    defender.Profit(attacker.Budget / 2);
                    defender.Profit(attacker.Army.Sum(u => u.Cost) + attacker.Weapons.Sum(w => w.Price));

                    planets.RemoveItem(attacker.Name);

                    winner = defender.Name;
                    loser = attacker.Name;

                    return string.Format(OutputMessages.WinnigTheWar, winner, loser);
                }


                else
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }

            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                attacker.Spend(attacker.Budget / 2);
                attacker.Profit(defender.Budget / 2);
                attacker.Profit(defender.Army.Sum(u => u.Cost) + defender.Weapons.Sum(w => w.Price));

                planets.RemoveItem(defender.Name);


                winner = attacker.Name;
                loser = defender.Name;
            }

            if (attacker.MilitaryPower < defender.MilitaryPower)
            {
                defender.Spend(defender.Budget / 2);
                defender.Profit(attacker.Budget / 2);
                defender.Profit(attacker.Army.Sum(u => u.Cost) + attacker.Weapons.Sum(w => w.Price));

                planets.RemoveItem(attacker.Name);

                winner = defender.Name;
                loser = attacker.Name;
            }

            return string.Format(OutputMessages.WinnigTheWar, winner, loser);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            double trainingFee = 1.25;
            planet.Spend(trainingFee);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}

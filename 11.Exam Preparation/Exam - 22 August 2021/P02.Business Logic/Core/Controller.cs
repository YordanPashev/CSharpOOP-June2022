namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using SpaceStation.Repositories;
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Utilities.Messages;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Models.Mission;
    using System.Collections.Generic;

    public class Controller : IController
    {
        IRepository<IAstronaut> astronauts;
        IRepository<IPlanet> planets;
        private int exploredPlanets = 0;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = type switch
            {
                nameof(Biologist) => new Biologist(astronautName),
                nameof(Geodesist) => new Geodesist(astronautName),
                nameof(Meteorologist) => new Meteorologist(astronautName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType)
            };

            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, astronaut.GetType().Name, astronaut.Name);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (string item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstrountsForMission = astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (!suitableAstrountsForMission.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            int astronautForMissionCount = suitableAstrountsForMission.Count();
            IPlanet planetForExplore = planets.FindByName(planetName);
            Mission mission = new Mission();

            mission.Explore(planetForExplore, suitableAstrountsForMission);

            exploredPlanets++;
            int deadAstrunautCount = astronautForMissionCount - suitableAstrountsForMission.Count();

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstrunautCount);
        }

        public string Report()
        {
            StringBuilder reportResult = new StringBuilder();

            reportResult.AppendLine($"{exploredPlanets} planets were explored!")
                        .AppendLine("Astronauts info:");

            foreach (IAstronaut astronaut in astronauts.Models)
            {
                reportResult.AppendLine($"Name: {astronaut.Name}")
                            .AppendLine($"Oxygen: {astronaut.Oxygen}")
                            .AppendLine($"Bag items: {string.Format(astronaut.Bag.Items.Count == 0 ? "none" : string.Join(", ", astronaut.Bag.Items))}");
            }

            return reportResult.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}

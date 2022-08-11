namespace Formula1.Core
{

    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Formula1.Utilities;
    using Formula1.Models.Cars;
    using Formula1.Models.Race;
    using Formula1.Repositories;
    using Formula1.Models.Pilot;
    using Formula1.Core.Contracts;
    using Formula1.Models.Contracts;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.CanRace)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = carRepository.FindByName(carModel);

            if (car == null)
            {
                throw new NullReferenceException
                    (string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            string carType = car.GetType().Name;

            return string.Format(string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, carType, carModel));
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException
                    (string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if (pilot == null || !pilot.CanRace || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car = type switch
            {
                nameof(Ferrari) => new Ferrari(model, horsepower, engineDisplacement),
                nameof(Williams) => new Williams(model, horsepower, engineDisplacement),
                _ => throw new InvalidOperationException
                        (string.Format(ExceptionMessages.InvalidTypeCar, type))
            };

            carRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName, numberOfLaps);
        }

        public string PilotReport()
        {
            StringBuilder allPilotessResults = new StringBuilder();

            foreach (IPilot pilot in pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                allPilotessResults.AppendLine($"Pilot {pilot.FullName} has {pilot.NumberOfWins} wins.");
            }

            return allPilotessResults.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder allRacesResults = new StringBuilder();

            foreach (IRace race in raceRepository.Models.Where(r => r.TookPlace))
            {
                allRacesResults.AppendLine(race.RaceInfo());
            }

            return allRacesResults.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException
                    (string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count() < 3)
            {
                throw new InvalidOperationException
                   (string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException
                   (string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> pilotsInCurrRace = race.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .Take(3)
                .ToList();

            race.TookPlace = true;

            IPilot winner = pilotsInCurrRace.First();
            IPilot second = pilotsInCurrRace[1];
            IPilot third = pilotsInCurrRace[2];

            winner.WinRace();

            StringBuilder raceresult = new StringBuilder();

            raceresult.AppendLine($"Pilot { winner.FullName } wins the { raceName } race.")
                      .AppendLine($"Pilot { second.FullName } is second in the { raceName } race.")
                      .AppendLine($"Pilot { third.FullName } is third in the { raceName } race.");

            return raceresult.ToString().TrimEnd();
        }
    }
}

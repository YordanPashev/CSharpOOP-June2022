namespace CarRacing.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using CarRacing.Models.Cars;
    using CarRacing.Models.Maps;
    using CarRacing.Repositories;
    using CarRacing.Core.Contracts;
    using CarRacing.Utilities.Messages;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Models.Racers;

    public class Controller : IController
    {
        private IMap map;
        private IRepository<ICar> cars;
        private IRepository<IRacer> racers;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = type switch
            {
                nameof(SuperCar) => new SuperCar(make, model, VIN, horsePower),
                nameof(TunedCar) => new TunedCar(make, model, VIN, horsePower),
                _ => throw new ArgumentException(ExceptionMessages.InvalidCarType)
            };

            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar,
                                 make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = type switch
            {
                nameof(ProfessionalRacer) => new ProfessionalRacer(username, car),
                nameof(StreetRacer) => new StreetRacer(username, car),
                _ => throw new ArgumentException(ExceptionMessages.InvalidRacerType)
            };

            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername) ?? throw new ArgumentException
                (string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));

            IRacer racerTwo = racers.FindBy(racerTwoUsername) ?? throw new ArgumentException
                (string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));

            string raceResult = map.StartRace(racerOne, racerTwo);
            return raceResult;
        }

        public string Report()
        {
            StringBuilder reportResult = new StringBuilder();

            foreach (IRacer racer in racers.Models.OrderByDescending(r => r.DrivingExperience)
                                                  .ThenBy(r => r.Username))
            {
                reportResult.AppendLine($"{racer.GetType().Name}: {racer.Username}")
                            .AppendLine($"--Driving behavior: {racer.RacingBehavior}")
                            .AppendLine($"--Driving experience: {racer.DrivingExperience}")
                            .AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");

            }

            return reportResult.ToString().TrimEnd();
        }
    }
}

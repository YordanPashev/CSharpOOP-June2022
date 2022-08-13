namespace CarRacing.Models.Racers
{

    using CarRacing.Models.Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const string racingBehavior = "strict";
        private const int initialDrivingExperience = 30;
        private const int drivingExperienceFromRace = 10;

        public ProfessionalRacer(string userName, ICar car)
            : base(userName, racingBehavior, initialDrivingExperience, car) { }

        public override void Race()
        {
            this.Car.Drive();

            this.DrivingExperience += drivingExperienceFromRace;
        }
    }
}

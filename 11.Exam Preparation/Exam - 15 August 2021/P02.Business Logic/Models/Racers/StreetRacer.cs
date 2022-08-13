namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    internal class StreetRacer : Racer
    {
        private const string racingBehavior = "aggressive";
        private const int initialDrivingExperience = 10;
        private const int drivingExperienceFromRace = 5;

        public StreetRacer(string userName, ICar car)
            : base(userName, racingBehavior, initialDrivingExperience, car) { }

        public override void Race()
        {
            this.Car.Drive();

            this.DrivingExperience += drivingExperienceFromRace;
        }
    }
}

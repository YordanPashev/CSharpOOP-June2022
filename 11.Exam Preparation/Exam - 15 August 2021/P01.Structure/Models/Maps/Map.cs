namespace CarRacing.Models.Maps
{

    using CarRacing.Utilities.Messages;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format
                    (OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                return string.Format
                    (OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();
            double racerOneBehavior = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            double racerTwoBehavior = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;

            double racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneBehavior;
            double racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoBehavior;

            string wisnerUsername = racerOneChance > racerTwoChance ? racerOne.Username
                                                                    : racerTwo.Username;

            return string.Format(OutputMessages.RacerWinsRace,
                                racerOne.Username, racerTwo.Username, wisnerUsername);
        }
    }
}

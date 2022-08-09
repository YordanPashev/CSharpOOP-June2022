namespace Gym.Models.Athletes
{

    using System;

    using Gym.Utilities.Messages;

    public class Weightlifter : Athlete
    {
        private const int stamina = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, stamina, numberOfMedals) { }

        public override string AllowedGym => "WeightliftingGym";

        public override void Exercise()
        {
            Stamina += 10;

            if (Stamina > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }     
        }
    }
}

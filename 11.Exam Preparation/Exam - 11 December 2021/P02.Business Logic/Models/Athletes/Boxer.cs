namespace Gym.Models.Athletes
{

    using System;

    using Gym.Utilities.Messages;

    public class Boxer : Athlete
    {
        private const int stamina = 60;

        public Boxer(string fullName, string motivation, int numberOfMedals)
           : base(fullName, motivation, stamina, numberOfMedals) { }

        public override string AllowedGym => "BoxingGym";

        public override void Exercise()
        {
            Stamina += 15;

            if (Stamina > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}

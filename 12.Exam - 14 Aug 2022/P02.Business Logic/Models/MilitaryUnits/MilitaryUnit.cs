namespace PlanetWars.Models.MilitaryUnits
{
    using System;

    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int initialEnduranceLevel = 1;

        public MilitaryUnit(double cost)
        {
            Cost = cost;
            this.EnduranceLevel = initialEnduranceLevel;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {
            EnduranceLevel++;

            if (EnduranceLevel > 20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}

namespace NavalVessels.Models.Vessels
{

    using NavalVessels.Models.Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double intialArmor = 200;
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, intialArmor)
        {
            submergeMode = false;
        }

        public bool SubmergeMode => this.submergeMode;

        public void ToggleSubmergeMode()
        {
            if (!this.submergeMode)
            {
                submergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }

            else if (submergeMode)
            {
                submergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" *Submerge mode: {string.Format(!submergeMode ? "OFF" : "ON")}";
        }
    }
}

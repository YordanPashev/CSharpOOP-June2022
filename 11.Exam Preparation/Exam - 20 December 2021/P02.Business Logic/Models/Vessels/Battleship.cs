namespace NavalVessels.Models.Vessels
{

    using NavalVessels.Models.Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double intialArmor = 300;
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, intialArmor)
        {
            sonarMode = false;
        }

        public bool SonarMode => this.sonarMode;

        public void ToggleSonarMode()
        {
            if (!this.sonarMode)
            {
                sonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }

            else if (this.sonarMode)
            {
                sonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" *Sonar mode: {string.Format(!sonarMode ? "OFF" : "ON")}";
        }
    }
}

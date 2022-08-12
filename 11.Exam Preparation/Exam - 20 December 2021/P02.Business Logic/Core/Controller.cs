namespace NavalVessels.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using NavalVessels.Models;
    using NavalVessels.Repositories;
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models.Vessels;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using NavalVessels.Repositories.Contracts;

    public class Controller : IController
    {
        private IRepository<IVessel> vessels;
        private ICollection<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new HashSet<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {

            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vessels.FindByName(attackingVesselName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            IVessel defender = vessels.FindByName(defendingVesselName);

            if (defender == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attacker.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attacker.Name);
            }

            if (defender.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defender.Name);
            }

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel,
                                 defender.Name, attacker.Name, defender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            ICaptain captain = new Captain(fullName);
            captains.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
            {
               return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            IVessel vessel = vesselType switch
            {
                nameof(Battleship) => new Battleship(name, mainWeaponCaliber, speed),
                nameof(Submarine) => new Submarine(name, mainWeaponCaliber, speed),
                _ => null
            };

            if (vessel == null)
            {
                return OutputMessages.InvalidVesselType;
            }

            vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel,
                                 vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel != null)
            {
                if (vessel.GetType().Name == nameof(Battleship))
                {
                    IBattleship battleship = vessel as Battleship;
                    battleship.ToggleSonarMode();
                    return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                }

                else
                {
                    ISubmarine submarine = vessel as Submarine;
                    submarine.ToggleSubmergeMode();
                    return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                }
            }

            else
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            return vessel.ToString();
        }
    }
}

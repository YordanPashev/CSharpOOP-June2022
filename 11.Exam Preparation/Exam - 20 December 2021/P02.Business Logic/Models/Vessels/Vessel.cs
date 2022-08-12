namespace NavalVessels.Models.Vessels
{

    using System;
    using System.Linq;
    using System.Collections.Generic;

    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        List<string> targets;
        private double initialArmorThickness;

        protected Vessel(string name, double mainWeaponCaliber, 
                         double speed, double initialArmorThickness)
        {
            this.Name = name;
            this.Speed = speed;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.ArmorThickness = initialArmorThickness;
            this.initialArmorThickness = initialArmorThickness;
            this.targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                this.captain = value;
            }
        }
        public double ArmorThickness
        {
            get => this.armorThickness;
            set
            {
                if (value < 0)
                {
                    armorThickness = 0;
                }

                this.armorThickness = value;
            }
        }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets => this.targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            targets.Add(target.Name);
        }

        public void RepairVessel() => this.ArmorThickness = initialArmorThickness;
        

        public override string ToString()
            => $"- {this.Name}" + Environment.NewLine +
               $" *Type: {this.GetType().Name}" + Environment.NewLine +
               $" *Armor thickness: {this.ArmorThickness}" + Environment.NewLine +
               $" *Main weapon caliber: {this.MainWeaponCaliber}" + Environment.NewLine +
               $" *Speed: {this.Speed} knots" + Environment.NewLine +
               $" *Targets: {string.Format(!targets.Any() ? "None" : string.Join(", ", targets))}" + Environment.NewLine;
    }
}

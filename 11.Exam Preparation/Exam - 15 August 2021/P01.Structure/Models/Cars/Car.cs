namespace CarRacing.Models.Cars
{

    using System;

    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Utilities.Messages;

    public abstract class Car : ICar
    {
        private const int vinRequiredLength = 17;

        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumtpionPerRace;

        protected Car(string make, string model, string VIN, int horsePower, 
                      double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make 
        {
            get => this. make;  

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }

                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }

                this.model = value;
            }
        }


        public string VIN
        {
            get => this.vin;

            private set
            {
                if (value.Length != vinRequiredLength)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }

                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }

                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;

            private set
            {
                if (value < 0)
                {
                    this.fuelAvailable = 0;
                }

                else
                {
                    this.fuelAvailable = value;
                }
            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumtpionPerRace;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }

                this.fuelConsumtpionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            this.fuelAvailable -= fuelConsumtpionPerRace;

            if (this.fuelAvailable < 0)
            {
                this.fuelAvailable = 0;
            }
        }
    }
}

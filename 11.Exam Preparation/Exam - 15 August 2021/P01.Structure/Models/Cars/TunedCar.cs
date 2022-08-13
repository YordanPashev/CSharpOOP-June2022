namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double initialFuelAmount = 65;
        private const double fuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, initialFuelAmount, fuelConsumptionPerRace) { }

        public override void Drive()
        {
            base.Drive();

            HorsePower = (int)(HorsePower * 0.97);
        }
    }
}

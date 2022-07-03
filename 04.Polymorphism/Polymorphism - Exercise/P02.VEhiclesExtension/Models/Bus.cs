namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity)
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
            AirConditionalConsumption = 1.4;
        }
    }
}


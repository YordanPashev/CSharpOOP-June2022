namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
            AirConditionalConsumption = 1.6;
        }
    }
}

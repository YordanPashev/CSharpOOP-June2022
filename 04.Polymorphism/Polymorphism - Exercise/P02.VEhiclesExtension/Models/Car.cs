namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumptionPerKm, double tankCapacity)
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
            AirConditionalConsumption = 0.9;
        }
    }
}

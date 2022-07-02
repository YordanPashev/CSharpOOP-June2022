using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double consumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            ConsumptionPerKm = consumptionPerKm;
        }

        public double FuelQuantity { get; protected set; }

        public double ConsumptionPerKm { get; protected set; }

        public double AirConditionalConsumption { get; set; }

        public void Drive(double distance)
        {
            double neededFuel = (distance * this.ConsumptionPerKm) + (distance * AirConditionalConsumption);
            if (neededFuel <= FuelQuantity)
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine(GetType().Name + $" travelled {distance} km");
                return;
            }

            Console.WriteLine(GetType().Name + " needs refueling");
        }

        public virtual void Refuel(double fuelAmount)
           => this.FuelQuantity += fuelAmount;

        public override string ToString()
            => GetType().Name + $": {this.FuelQuantity:F2}";
    }
}

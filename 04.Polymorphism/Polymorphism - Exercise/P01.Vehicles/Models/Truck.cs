using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private double airConditionalConsumption = 1.6;

        public Truck(double fuelQuantity, double consumptionPerKm)
            : base(fuelQuantity, consumptionPerKm) { }

        public override void Drive(double distance)
        {
            double neededFuel = (distance * this.ConsumptionPerKm) + (distance * airConditionalConsumption);
            if (neededFuel <= FuelQuantity)
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine(GetType().Name + $" travelled {distance} km");
                return;
            }

            Console.WriteLine(GetType().Name + " needs refueling");
        }

        public override void Refuel(double fuelAmount)
           => this.FuelQuantity += fuelAmount * 0.95;
    }
}

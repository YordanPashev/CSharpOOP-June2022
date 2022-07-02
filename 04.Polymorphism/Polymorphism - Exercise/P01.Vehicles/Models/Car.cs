using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private double airConditionalConsumption = 0.9;

        public Car(double fuelQuantity, double consumptionPerKm)
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
    }
}

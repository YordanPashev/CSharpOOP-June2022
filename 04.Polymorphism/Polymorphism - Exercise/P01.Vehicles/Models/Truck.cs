using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {

        public Truck(double fuelQuantity, double consumptionPerKm)
            : base(fuelQuantity, consumptionPerKm) 
        {
            AirConditionalConsumption = 1.6;
        }

        public override void Refuel(double fuelAmount)
           => this.FuelQuantity += fuelAmount * 0.95;
    }
}

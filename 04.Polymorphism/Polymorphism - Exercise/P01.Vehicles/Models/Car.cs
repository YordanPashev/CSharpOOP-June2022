using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {

        public Car(double fuelQuantity, double consumptionPerKm)
            : base(fuelQuantity, consumptionPerKm) 
        {
            AirConditionalConsumption = 0.9;
        }
    }
}

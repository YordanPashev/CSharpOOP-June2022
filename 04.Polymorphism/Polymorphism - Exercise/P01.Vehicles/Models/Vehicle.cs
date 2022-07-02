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

        public virtual void Refuel(double fuelAmount)
           => this.FuelQuantity += fuelAmount;

        public abstract void Drive(double distance);

        public override string ToString()
            => GetType().Name + $": {this.FuelQuantity:F2}";
    }
}

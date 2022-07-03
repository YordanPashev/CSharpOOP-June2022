using System;
using System.Collections.Generic;
using System.Linq;
namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double consumptionPerKm, double tankCapacity)
        {
            ConsumptionPerKm = consumptionPerKm;
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
        }

        public double ConsumptionPerKm { get; private set; }

        public virtual double AirConditionalConsumption { get; set; }

        public double TankCapacity { get; private set; }

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }

                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public void Drive(double distance, bool isAirConditionarOn)
        {
            double neededFuel;

            if (!isAirConditionarOn)
            {
                neededFuel = distance * this.ConsumptionPerKm;
            }

            else
            {
                neededFuel = (distance * this.ConsumptionPerKm) + (distance * AirConditionalConsumption);
            }

            if (neededFuel <= FuelQuantity)
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine(GetType().Name + $" travelled {distance} km");
                return;
            }

            Console.WriteLine(GetType().Name + " needs refueling");
        }

        public virtual void Refuel(double fuelAmount)
        {

            if (fuelAmount + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
                return;
            }

            if (this.GetType().Name == "Truck")
            {
                this.FuelQuantity += fuelAmount * 0.95;
            }

            else
            {
                this.FuelQuantity += fuelAmount;
            }
        }

        public override string ToString()
            => GetType().Name + $": {this.FuelQuantity:F2}";
    }
}

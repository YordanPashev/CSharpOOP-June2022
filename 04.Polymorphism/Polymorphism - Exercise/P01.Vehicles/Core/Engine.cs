using System;
using System.Collections.Generic;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    { 

        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQunatity = double.Parse(carInfo[1]);
            double carConsumptionPerKm = double.Parse(carInfo[2]);
            Vehicle car = new Car(carFuelQunatity, carConsumptionPerKm);

            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQunatity = double.Parse(truckInfo[1]);
            double truckConsumptionPerKm = double.Parse(truckInfo[2]);
            Vehicle truck = new Truck(truckFuelQunatity, truckConsumptionPerKm);

            int numberOfCmds = int.Parse(Console.ReadLine());

            string cmd = string.Empty;

            for (int i = 1; i <= numberOfCmds; i++)
            {
                cmd = Console.ReadLine();
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string vehicleType = cmdArgs[1];

                if (action == "Drive")
                {
                    double distance = double.Parse(cmdArgs[2]);
                    TryToDrive(car, truck, vehicleType, distance);
                }

                else if (action == "Refuel")
                {
                    double fuelAmount = double.Parse(cmdArgs[2]);
                    Refuel(car, truck, vehicleType, fuelAmount);
                }
            }

            DisplayRemainingFuelInTheTanks(car, truck);
        }

        private void TryToDrive(Vehicle car, Vehicle truck, string vehicleType, double distance)
        {
            if (vehicleType == "Car")
            {
                car.Drive(distance);
            }

            else if (vehicleType == "Truck")
            {
                truck.Drive(distance);
            }
        }

        private void Refuel(Vehicle car, Vehicle truck, string vehicleType, double fuelAmount)
        {
            if (vehicleType == "Car")
            {
                car.Refuel(fuelAmount);
            }

            else if (vehicleType == "Truck")
            {
                truck.Refuel(fuelAmount);
            }
        }

        private void DisplayRemainingFuelInTheTanks(Vehicle car, Vehicle truck)
        {
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}

using System;
using Vehicles.Models;
using System.Collections.Generic;

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
            double carTankCapacity = double.Parse(carInfo[3]);
            Vehicle car = new Car(carFuelQunatity, carConsumptionPerKm, carTankCapacity);

            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQunatity = double.Parse(truckInfo[1]);
            double truckConsumptionPerKm = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            Vehicle truck = new Truck(truckFuelQunatity, truckConsumptionPerKm, truckTankCapacity);

            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQunatity = double.Parse(busInfo[1]);
            double busConsumptionPerKm = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            Vehicle bus = new Bus(busFuelQunatity, busConsumptionPerKm, busTankCapacity);

            int numberOfCmds = int.Parse(Console.ReadLine());

            Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>
            {
                { "Car", car },
                { "Truck", truck },
                { "Bus", bus }
            };

            string cmd = string.Empty;

            for (int i = 1; i <= numberOfCmds; i++)
            {
                cmd = Console.ReadLine();
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string vehicleType = cmdArgs[1];

                if (action.Contains("Drive"))
                {
                    bool isAirConditionarOn = true;

                    if (action == "DriveEmpty")
                    {
                        isAirConditionarOn = false;
                    }

                    double distance = double.Parse(cmdArgs[2]);
                    vehicles[vehicleType].Drive(distance, isAirConditionarOn);
                }

                else if (action == "Refuel")
                {
                    double fuelAmount = double.Parse(cmdArgs[2]);

                    if (fuelAmount <= 0)
                    {
                        Console.WriteLine("Fuel must be a positive number");
                        continue;
                    }

                    vehicles[vehicleType].Refuel(fuelAmount);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Value.ToString());
            }
        }
    }
}

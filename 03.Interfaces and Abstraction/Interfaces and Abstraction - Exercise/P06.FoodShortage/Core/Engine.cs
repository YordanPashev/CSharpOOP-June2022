using System;
using System.Linq;
using BorderControl;
using FoodShortage.Models;
using FoodShortage.Contracts;
using System.Collections.Generic;

namespace FoodShortage.Core
{
    internal class Engine : IEngine
    {
        private Dictionary<string, IBuyer> buyers;
        private int TotalAmountOfFood = 0;

        public Engine()
        {
            this.buyers = new Dictionary<string, IBuyer>();
        }

        public void Run()
        {
            int numberOfBuyers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBuyers; i++)
            {
                AddBuyer();
            }

            string buyersName;

            while ((buyersName = Console.ReadLine()) != "End")
            {
                TryToBuyFood(buyersName);
            }

            TotalAmountOfFood = buyers.Sum(b => b.Value.Food);
            Console.WriteLine(TotalAmountOfFood);

        }

        private void AddBuyer()
        {
            string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = cmdArgs[0];
            int age = int.Parse(cmdArgs[1]);
            IBuyer buyer = null;

            if (cmdArgs.Length == 4)
            {
                string id = cmdArgs[2];
                string birthdate = cmdArgs[3];
                buyer = new Citizen(name, age, id, birthdate);
            }

            else if (cmdArgs.Length == 3)
            {
                string group = cmdArgs[2];
                buyer = new Rebel(name, age, group);
            }

            buyers.Add(name, buyer);
        }

        private void TryToBuyFood(string buyersName)
        {
            if (buyers.ContainsKey(buyersName))
            {
                buyers[buyersName].BuyFood();
            }
        }
    }
}

using BirthdayCelebrations.Contracts;
using BorderControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations.Core
{
    internal class Engine : IEngine
    {
        private List<IBirthable> habitatorWithBirthdate;

        public Engine()
        {
            this.habitatorWithBirthdate = new List<IBirthable>();
        }

        public void Run()
        {
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string habitatorType = cmdArgs[0];
                var isHabitatorHasBirthDate = habitatorType == "Citizen" || habitatorType == "Pet";

                if (isHabitatorHasBirthDate)
                {
                    AddHabitatorToTheList(cmdArgs, habitatorType);
                }
            }

            string year = Console.ReadLine();

            DisplayAllHabitatorsBirthdatesFromTheSpecYear(year);
        }

        private void DisplayAllHabitatorsBirthdatesFromTheSpecYear(string year)
        {
            foreach (IBirthable habitator in habitatorWithBirthdate)
            {
                if (habitator.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(habitator.Birthdate.ToString());
                }
            }
        }

        private void AddHabitatorToTheList(string[] cmdArgs, string habitatorType)
        {
            IBirthable habitator = null;

            if (habitatorType == "Citizen")
            {
                string name = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                string id = cmdArgs[3];
                string birthdate = cmdArgs[4];
                habitator = new Citizen(name, age, id, birthdate);
            }

            else if (habitatorType == "Pet")
            {
                string name = cmdArgs[1];
                string birthdate = cmdArgs[2];
                habitator = new Pet(name,birthdate);
            }

            habitatorWithBirthdate.Add(habitator);
        }
    }
}

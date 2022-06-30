using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Habitator> habitators = new List<Habitator>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    Citizen person = new Citizen(name, age, id);
                    habitators.Add(person);
                }

                else if (cmdArgs.Length == 2)
                {
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];

                    Robot robot = new Robot(model, id);
                    habitators.Add(robot);
                }
            }

            string fakeIdEndNumber = Console.ReadLine();

            foreach (Habitator habitator in habitators)
            {
                if (habitator.CheckForFakeId(fakeIdEndNumber))
                {
                    Console.WriteLine(habitator.Id);
                }
            }
        }
    }
}

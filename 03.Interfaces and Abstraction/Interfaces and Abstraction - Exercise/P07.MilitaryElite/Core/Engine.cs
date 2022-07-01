using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private Dictionary<string, ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new Dictionary<string,ISoldier>();
        }
        public void Run()
        {

            string cmd = string.Empty;
            while ((cmd = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] inputInfo = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string result = ProccesInputLine(inputInfo, soldiers);

                    Console.WriteLine(result);
                }
                catch (Exception)
                { }
            }
        }

        private static string ProccesInputLine(string[] args, Dictionary<string, ISoldier> soldiers)
        {
            string soldierType = args[0];
            string id = args[1];
            string firstName = args[2];
            string lastName = args[3];

            ISoldier soldier = null;

            if (soldierType == "Private")
            {
                decimal salary = decimal.Parse(args[4]);
                soldier = new Private(firstName, lastName, id, salary);
            }

            else if (soldierType == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(args[4]);
                Dictionary<string, IPrivate> privates = new Dictionary<string, IPrivate>();

                for (int i = 5; i < args.Length; i++)
                {
                    string soldierId = args[i];
                    var currentSoldier = (IPrivate)soldiers[soldierId];
                    privates.Add(soldierId, currentSoldier);
                }

                soldier = new LieutenantGeneral(firstName, lastName, id, salary, privates);
            }

            else if (soldierType == "Engineer")
            {
                decimal salary = decimal.Parse(args[4]);
                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);

                if (!isValidCorps)
                {
                    throw new Exception();
                }


                ICollection<IRepair> repairs = new List<IRepair>();

                for (int i = 6; i < args.Length; i += 2)
                {
                    string currentName = args[i];
                    int hours = int.Parse(args[i + 1]);
                    IRepair repair = new Repair(currentName, hours);
                    repairs.Add(repair);
                }

                soldier = new Engineer(firstName, lastName, id, salary, corps, repairs);
            }

            else if (soldierType == "Commando")
            {
                decimal salary = decimal.Parse(args[4]);
                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);


                if (!isValidCorps)
                {
                    throw new Exception();
                }

                ICollection<IMission> missions = new List<IMission>();

                for (int i = 6; i < args.Length; i += 2)
                {
                    string missionName = args[i];
                    string missionState = args[i + 1];
                    bool isValidMissionState = Enum.TryParse<MissionState>(missionState, out MissionState stateResult);


                    if (!isValidMissionState)
                    {
                        continue;
                    }

                    IMission mission = new Mission(missionName, stateResult);
                    missions.Add(mission);
                }

                soldier = new Commando(firstName, lastName, id, salary, corps, missions);
            }

            else if (soldierType == "Spy")
            {
                int codeNumber = int.Parse(args[4]);
                soldier = new Spy(firstName, lastName, id, codeNumber);
            }

            soldiers.Add(id, soldier);

            return soldier.ToString();
        }
    }
}

using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            bool isProcessingData = true;

            while (isProcessingData)
            {
                string cmd = string.Empty;

                try
                {
                    while ((cmd = Console.ReadLine()) != "END")
                    {
                        string[] cmdArgs = cmd.Split(";");
                        string action = cmdArgs[0];

                        if (action == "Team")
                        {
                            TryToAddTeam(teams, cmdArgs);
                        }

                        else if (action == "Add")
                        {
                            TryToAddPlayer(teams, cmdArgs);
                        }

                        else if (action == "Remove")
                        {
                            TryToRemovePlayer(teams, cmdArgs);
                        }

                        else if (action == "Rating")
                        {
                            DisplayTeamRaiting(teams, cmdArgs);
                        }
                    }
                }

                catch (Exception e)
                {
                    if (e.Message == "A name should not be empty.")
                    {
                        Console.WriteLine(e.Message);
                        isProcessingData = false;
                        break;
                    }

                    Console.WriteLine(e.Message);
                }

                if (cmd == "END")
                {
                    isProcessingData = false;
                    break;
                }
            }
        }

        private static void DisplayTeamRaiting(Dictionary<string, Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];

            if (!teams.ContainsKey(teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Console.WriteLine($"{teamName} - {teams[teamName].GetTeamRaiting()}");
        }

        private static void TryToRemovePlayer(Dictionary<string, Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            string playerName = cmdArgs[2];

            if (!teams.ContainsKey(teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
            
            teams[teamName].RemovePlayer(playerName);
        }

        private static void TryToAddPlayer(Dictionary<string, Team> teams, string[] cmdArgs)
        {

            string teamName = cmdArgs[1];
            string playerName = cmdArgs[2];
            int enduranceValue = int.Parse(cmdArgs[3]);
            int sprintValue = int.Parse(cmdArgs[4]);
            int dribbleValue = int.Parse(cmdArgs[5]);
            int passingValue = int.Parse(cmdArgs[6]);
            int shootingValue = int.Parse(cmdArgs[7]);

            if (!teams.ContainsKey(teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
            Dictionary<string, int> stats = new Dictionary<string, int>
             {
                 { "Endurance", enduranceValue},
                 { "Sprint", sprintValue },
                 { "Dribble", dribbleValue },
                 { "Passing", passingValue },
                 { "Shooting", shootingValue }
            };

            teams[teamName].AddPlayer(playerName, stats);

        }

        private static void TryToAddTeam(Dictionary<string, Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            Team teamToAddToList = new Team(teamName);
            teams.Add(teamName, teamToAddToList);
        }
    }
}

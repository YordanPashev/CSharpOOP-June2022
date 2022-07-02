using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Dictionary<string, int> stats = new Dictionary<string, int>
        {
            { "Endurance", 0},
            { "Sprint", 0},
            { "Dribble", 0},
            { "Passing", 0 },
            { "Shooting", 0 }
        };

        public Player(string name, Dictionary<string, int> stats)
        {
            Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public Dictionary<string, int> Stats
        {
            get => stats;
            private set 
            {
                foreach (var (statsName, currStat) in value)
                {
                    if (currStat < 0 || currStat > 100)
                    {
                        throw new ArgumentException($"{statsName} should be between 0 and 100.");
                    }

                    stats[statsName] = currStat;
                }
            }
        }

        public double OverallSkillLeve()
            => stats.Values.Sum() / 5.0;

    }
}

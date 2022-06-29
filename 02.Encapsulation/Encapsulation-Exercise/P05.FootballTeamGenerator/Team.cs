using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            Name = name;
            this.players = new Dictionary<string, Player>();
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

        public void AddPlayer(string player, Dictionary<string, int> currStats)
        {

            Player playerInfo = new Player(player, currStats);
            players.Add(player, playerInfo);           
        }

        public void RemovePlayer(string player)
        {
            if (!players.ContainsKey(player))
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team.");
            }

            players.Remove(player);
        }

        public double GetTeamRaiting()
        {
            double result = 0;

            if (players.Count == 0)
            {
                return 0;
            }

            foreach (var player in players)
            {
                result += player.Value.OverallSkillLeve();
            }

            return Math.Round((result / players.Count), 0);
        }
    }
}

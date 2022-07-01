using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enums;


namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string firstName, string lastName, string id, decimal salary, Corps Corps, ICollection<IMission> missions)
            : base(firstName, lastName, id, salary, Corps)
        {
            Missions = missions;
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");

            foreach (var currentMission in this.Missions)
            {
                sb.AppendLine("  " + currentMission.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string firstName, string lastName, string id, decimal salary, Dictionary<string, IPrivate> privates) : base(firstName, lastName, id, salary)
        {
            Privates = privates;
        }

        public Dictionary<string, IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var currentPrivate in this.Privates)
            {
                sb.AppendLine("  " + currentPrivate.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

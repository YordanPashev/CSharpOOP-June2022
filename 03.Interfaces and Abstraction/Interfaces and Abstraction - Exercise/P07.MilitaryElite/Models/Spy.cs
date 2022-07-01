using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, string id, int codeNumber) : base(firstName, lastName, id)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            return base.ToString()
                    + Environment.NewLine +
                   $"Code Number: {this.CodeNumber}";
        }
    }
}

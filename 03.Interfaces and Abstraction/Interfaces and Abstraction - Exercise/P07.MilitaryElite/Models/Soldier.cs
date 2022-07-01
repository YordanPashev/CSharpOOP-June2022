using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite
{
    public class Soldier : ISoldier
    {
        public Soldier(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Id { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}

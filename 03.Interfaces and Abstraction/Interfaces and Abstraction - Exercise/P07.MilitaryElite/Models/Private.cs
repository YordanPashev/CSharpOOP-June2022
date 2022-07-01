using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, string id, decimal salary)
                       : base(firstName, lastName, id)
        {
            Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
            => $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}";
    }
}

using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string firstName, string lastName, string id, decimal salary, Corps corps) : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }
    }
}

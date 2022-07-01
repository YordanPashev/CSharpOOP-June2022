using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string name, int hoursWorked)
        {
            PartName = name;
            HoursWorked = hoursWorked;
        }

        public string PartName { get; set; }

        public int HoursWorked { get; set; }

        public override string ToString()
           => $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }
}

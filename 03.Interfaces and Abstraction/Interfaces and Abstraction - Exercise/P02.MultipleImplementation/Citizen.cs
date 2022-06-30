using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string iD, string birthdate)
        {
            Name = name;
            Age = age;
            Id = iD;
            Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get ; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }
    }
}

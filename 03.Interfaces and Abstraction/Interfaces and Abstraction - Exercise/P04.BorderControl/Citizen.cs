using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Habitator
    { 
        public Citizen(string name, int age, string id) : base (id)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}

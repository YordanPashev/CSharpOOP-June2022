using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Tomcat : Cat
    {
        private const string Gender = "Male";
        public Tomcat(string name, int age)
            : base(name, age, Gender) { }

        public override string ProduceSound() 
            =>  "MEOW";
    }
}

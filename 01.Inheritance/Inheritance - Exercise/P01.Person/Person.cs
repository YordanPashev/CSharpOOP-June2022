using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public virtual int Age
        { 
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("A person age can't be negative.");
                }

                age = value;
            }
        }

        public override string ToString()
        =>$"Name: {Name}, Age: {Age}";
    }
}

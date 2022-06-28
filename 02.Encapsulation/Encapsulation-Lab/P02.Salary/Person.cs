using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public decimal Salary { get; private set; }
        public int Age { get; private set; }

        public override string ToString()
            => $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";

        public decimal IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage /= 2;
            }

            this.Salary += (percentage * this.Salary) / 100;
            return this.Salary;
        }
    }
}

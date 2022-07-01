using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Pet : Habitator, IBirthable
    {
        public Pet(string name, string birthdate) : base(name)
        {
            Birthdate = birthdate;
        }

        public string Birthdate { get; private set; }
    }
}


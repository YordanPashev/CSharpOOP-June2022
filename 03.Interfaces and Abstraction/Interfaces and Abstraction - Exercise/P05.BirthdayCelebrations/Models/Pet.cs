using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;

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


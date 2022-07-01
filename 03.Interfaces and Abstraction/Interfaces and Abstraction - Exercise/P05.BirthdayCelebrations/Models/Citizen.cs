using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;

namespace BorderControl
{
    public class Citizen : Habitator, IIdentifiable, IBirthable
    { 
        public Citizen(string name, int age, string id, string birthdate) 
            : base (name)
        {
            Id = id;
            Age = age;
            Birthdate = birthdate;
        }

        public int Age { get; set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}

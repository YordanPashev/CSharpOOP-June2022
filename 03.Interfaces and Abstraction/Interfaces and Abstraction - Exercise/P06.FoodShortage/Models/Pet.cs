using FoodShortage.Models;
using FoodShortage.Contracts;

namespace FoodShortage
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


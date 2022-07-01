using FoodShortage.Models;
using FoodShortage.Contracts;

namespace BorderControl
{
    public class Citizen : Habitator, IIdentifiable, IBirthable, IBuyer
    { 
        public Citizen(string name, int age, string id, string birthdate) 
            : base (name)
        {
            Id = id;
            Age = age;
            Birthdate = birthdate;
            Food = 0;
        }

        public int Age { get; set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
